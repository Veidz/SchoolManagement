using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System.Collections.Generic;

namespace SchoolManagement.Database
{
  public class DatabaseManager
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
  }
}
