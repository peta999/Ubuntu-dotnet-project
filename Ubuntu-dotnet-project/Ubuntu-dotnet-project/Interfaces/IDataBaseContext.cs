using System;
using Ubuntu_dotnet_project.Models;

public interface IDataBaseContext
{
    public bool AddDataLog(DataLog datalog);
}