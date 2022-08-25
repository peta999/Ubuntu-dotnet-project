namespace Ubuntu_dotnet_project.Models;

public class DataLog
{
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }

    public DataLog(DateTime time, double temperature, double humidity)
    {
        Time = time;
        Temperature = temperature;
        Humidity = humidity;
    }
}

