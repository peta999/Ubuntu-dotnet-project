using MQTTnet;
using MQTTnet.Client;

namespace Ubuntu_dotnet_project.MQTTClient;


public class MQTTClient
{
    public static async Task Handle_Received_Application_Message()
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
                Console.WriteLine("Received application message2.");
                if(e.ApplicationMessage.Topic == "test")
                {
                    // save in db and log it
                    Console.WriteLine("Topic: test | Message: " + e.ApplicationMessage.ConvertPayloadToString());
                    DataBaseContext.
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

    public static async Task Subscribe_Topic()
    {
        /*
         * This sample subscribes to a topic.
         */

        var mqttFactory = new MqttFactory();

        using (var mqttClient = mqttFactory.CreateMqttClient())
        {
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("192.168.2.24", 1883)
                .Build();

            await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(("test"))
                .Build();

            var response = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);

            Console.WriteLine("MQTT client subscribed to topic.");

            // The response contains additional data sent by the server after subscribing.
            //response.DumpToConsole();
        }
    }
}