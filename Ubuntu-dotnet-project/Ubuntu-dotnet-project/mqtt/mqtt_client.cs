using MQTTnet;
using MQTTnet.Client;
using System.Globalization;
using Ubuntu_dotnet_project.Models;

namespace Ubuntu_dotnet_project.MQTTClient;


public class MQTTClient : BackgroundService
{
    private readonly IDataBaseContext _db;
    public MQTTClient(IDataBaseContext _db)
    {
        this._db = _db;
    }    
    
    // Handle_Received_Application_Message
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        /*
         * This sample subscribes to a topic and processes the received message.
         */

        var mqttFactory = new MqttFactory();

        using (var mqttClient = mqttFactory.CreateMqttClient())
        {
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("192.168.2.24", 1883)
                .Build();

            // Setup message handling before connecting so that queued messages
            // are also handled properly. When there is no event handler attached all
            // received messages get lost.
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                // This is called after 
                Console.WriteLine("Received application message.");
                if(e.ApplicationMessage.Topic == "test")
                {
                    // save in db and log it
                    Console.WriteLine("Topic: test | Message: " + e.ApplicationMessage.ConvertPayloadToString());

                    DataLog data = ParseDateReturnDataLog(e.ApplicationMessage.ConvertPayloadToString());
                    _db.AddDataLog(data);
                } else
                {
                    // log it
                    Console.WriteLine("Topic: " + e.ApplicationMessage.Topic + " | Message: " + e.ApplicationMessage.ConvertPayloadToString());
                }
                return Task.CompletedTask;
            };

            await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter("test")
                .Build();

            await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);

            Console.WriteLine("MQTT client subscribed to topic.");

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }

    public DataLog ParseDateReturnDataLog(string data)
    {
        // payload will have following format:
        // "temp, hum, YYYY-MM-DD HH:MM:SS"
        // 25.1, 59.1, 2022-08-25 11:05:43


        string[] dataArray = data.Split(',');
        double temp;
        double hum;
        DateTime date;
        
        if (double.TryParse(dataArray[0], NumberStyles.Any, CultureInfo.InvariantCulture, out temp) && double.TryParse(dataArray[1], NumberStyles.Any, CultureInfo.InvariantCulture, out hum))
        {
            return new DataLog(DateTime.Parse(dataArray[2]), temp, hum);
        }
        else
        {
            return null;
        }
    }
}