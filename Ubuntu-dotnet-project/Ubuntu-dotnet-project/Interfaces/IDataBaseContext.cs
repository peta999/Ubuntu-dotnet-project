using Ubuntu_dotnet_project.Models;
using Microsoft.Data.Sqlite;
using Dapper;

public class DataBaseContext : IDataBaseContext
{
    private readonly IConfiguration config;
    private readonly String cString;
    
    public DataBaseContext(IConfiguration config)
    {
        this.config = config;
        cString = config.GetConnectionString("mainDB");

    }
    public bool AddDataLog(DataLog datalog)
    {
        using (var connection = new SqliteConnection(cString))
        {
            connection.Open();
            connection.Execute("INSERT INTO DataLog (Time, Temperature, Humidity) VALUES (@Time, @Temperature, @Humidity)", datalog);
        }
        return true;
    }
    public async Task<List<DataLog>> GetDataLogsByDay(DateOnly date)
    {
        // Convert date in DateTime object
        var dt = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        var dt1 = dt.AddDays(1);

        using (var connection = new SqliteConnection(cString))
        {
            connection.Open();
            var result = await connection.QueryAsync<DataLog>("SELECT * FROM DataLog WHERE Time => @dt AND Time <= @dt1", new { dt = dt, dt1 = dt1 });
            return result.ToList();
        }
    }
    public async Task<List<DataLog>> GetDataLogsByWeek(DateOnly date)
    {
        // Convert date in DateTime object
        var dt = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        var dt1 = dt.AddDays(7);

        using (var connection = new SqliteConnection(cString))
        {
            connection.Open();
            var result = await connection.QueryAsync<DataLog>("SELECT * FROM DataLog WHERE Time => @dt AND Time <= @dt1", new { dt = dt, dt1 = dt1 });
            return result.ToList();
        }
    }
    public async Task<List<DataLog>> GetDataLogsByMonth(DateOnly date)
    {
        // Convert date in DateTime object
        var dt = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        var dt1 = dt.AddMonths(1);

        using (var connection = new SqliteConnection(cString))
        {
            connection.Open();
            var result = await connection.QueryAsync<DataLog>("SELECT * FROM DataLog WHERE Time => @dt AND Time <= @dt1", new { dt = dt, dt1 = dt1 });
            return result.ToList();
        }
    }
    public async Task<List<DataLog>> GetDataLogsByYear(DateOnly date)
    {
        // Convert date in DateTime object
        var dt = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        var dt1 = dt.AddYears(1);

        using (var connection = new SqliteConnection(cString))
        {
            connection.Open();
            var result = await connection.QueryAsync<DataLog>("SELECT * FROM DataLog WHERE Time => @dt AND Time <= @dt1", new { dt = dt, dt1 = dt1 });
            return result.ToList();
        }
    }

}