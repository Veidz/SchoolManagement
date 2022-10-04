using SchoolManagement.Models;
using System.Collections.Generic;

namespace SchoolManagement.Protocols
{
  public interface IDatabase
  {
    List<Student> GetAllStudents();
    void CreateStudent(string name);
  }
}
