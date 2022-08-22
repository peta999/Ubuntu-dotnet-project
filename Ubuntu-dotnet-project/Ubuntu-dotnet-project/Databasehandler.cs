using Microsoft.Data.Sqlite;



public static class DatabaseHandler
{
    public static void CheckCreateDatabase(IConfiguration config)
    {
        string filePath = config.GetConnectionString("mainDB");
        if (!File.Exists(filePath))
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
                Time DATETIME PRIMARY KEY AUTOINCREMENT,
                Temperature REAL,
                Humidity REAL);";
                command1.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

