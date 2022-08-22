using System;
using Ubuntu_dotnet_project.Models;

interface IDataBaseContext
{
    public bool AddDataLog(DataLog datalog);
}