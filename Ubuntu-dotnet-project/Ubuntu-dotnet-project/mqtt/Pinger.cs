namespace Ubuntu_dotnet_project.mqtt;

public class Pinger : BackgroundService
{
    public Pinger()
    {
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.GetAsync("localhost", stoppingToken);
            }

            await Task.Delay(10 * 1000, stoppingToken);
        }
    }
}

