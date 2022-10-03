using SchoolManagement.Models;
using System.Collections.Generic;

namespace SchoolManagement.Protocols
{
  public interface IDatabase
  {
    void Connect();
    void Disconnect();
    List<Student> GetAllStudents();
  }
}
