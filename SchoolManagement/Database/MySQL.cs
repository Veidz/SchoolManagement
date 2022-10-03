using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace SchoolManagement.Database
{
  public class MySQL
  {
    private static readonly string host = "localhost";
    private static readonly string port = "3306";
    private static readonly string user = "root";
    private static readonly string password = "root";
    private static readonly string dbname = "school_management";

    private static MySqlConnection sqlConnection;

    public MySQL()
    {
      try
      {
        sqlConnection = new MySqlConnection($"server={host};user={user};database={dbname};port={port};password={password}");
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message);
        throw new Exception("Error connecting to database");
      }
    }
  }
}
