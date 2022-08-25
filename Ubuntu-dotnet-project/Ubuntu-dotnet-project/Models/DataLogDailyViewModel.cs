namespace Ubuntu_dotnet_project.Models;

/// <summary>
/// This is used to represent one day in the view.
/// </summary>
public class DataLogDailyViewModel
{
    /// <summary>
    /// This will be holding 1440 <see cref="DataLog"/> as List. <br/>
    /// This means one <see cref="DataLog"/> for every minute.
    /// </summary>
    readonly List<DataLog> dailyDataLogs;
    /// <summary>
    /// This represents the date for all the <see cref="DataLog"/>.
    /// </summary>
    readonly DateOnly dateOnly;

    public DataLogDailyViewModel(List<DataLog> dailyDataLogs, DateOnly dateOnly)
    {
        this.dailyDataLogs = dailyDataLogs;
        this.dateOnly = dateOnly;
    }
}
