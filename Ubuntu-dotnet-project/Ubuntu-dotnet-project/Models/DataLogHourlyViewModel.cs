namespace Ubuntu_dotnet_project.Models;

/// <summary>
/// This is used to represent one day in the view.
/// </summary>
public class DataLogHourlyViewModel
{
    /// <summary>
    /// This will be holding 1440 <see cref="DataLog"/> as List. <br/>
    /// This means one <see cref="DataLog"/> for every minute.
    /// </summary>
    private readonly List<DataLog> hourlyDataLogs;
    /// <summary>
    /// This represents the date for all the <see cref="DataLog"/>.
    /// </summary>
    private readonly DateOnly dateOnly;

    public DataLogHourlyViewModel(List<DataLog> hourlyDataLogs, DateOnly dateOnly)
    {
        this.hourlyDataLogs = hourlyDataLogs;
        this.dateOnly = dateOnly;
    }
}
