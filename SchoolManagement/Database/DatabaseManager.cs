using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SchoolManagement.Database
{
  public class DatabaseManager : IDatabase
  {
    readonly IDatabase Database;

    public DatabaseManager(IDatabase database)
    {
      Database = database;
    }

    public List<Student> GetAllStudents()
    {
      return Database.GetAllStudents();
    }

    public void CreateStudent(string name)
    {
      try
      {
        Database.CreateStudent(name);
      }
      catch (Exception exception)
      {
        //MessageBox.Show(exception.Message);
        throw new Exception("Error creating student");
      }
    }
  }
}
