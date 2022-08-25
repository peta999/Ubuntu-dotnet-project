using Microsoft.Data.Sqlite;
using System.IO;



public static class DatabaseHandler
{
    public static void CheckCreateDatabase(IConfiguration config)
    {
        string filePath = config.GetConnectionString("mainDB");
        if (!File.Exists(@"C:\Users\hoppe\Documents\GitHub\Ubuntu-dotnet-project\Ubuntu-dotnet-project\Ubuntu-dotnet-project\database.db"))
        {
            using (var connection = new SqliteConnection(filePath))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not open database: " + e.Message);
                    return;
                }

                // create Datalog table
                SqliteCommand? command1 = connection.CreateCommand();
                command1.CommandText =
                    @"
				CREATE TABLE DataLog (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                Time DATETIME,
                Temperature REAL,
                Humidity REAL);";
                command1.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

