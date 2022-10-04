using NUnit.Framework;
using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System.Collections.Generic;

namespace SchoolManagement.Tests
{
  public class Models
  {
    [Test]
    public void Ensure_GetAllStudents_Works_Properly()
    {

      Student studentMock = new Student()
      {
        ID = 1,
        Name = "Ada Lovelace"
      };

      List<Student> studentsMock = new List<Student>()
      {
        studentMock
      };

      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
      dbMock.Setup((db) => db.GetAllStudents()).Returns(studentsMock);

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
      List<Student> students = dbManager.GetAllStudents();

      Assert.That(students, Is.EqualTo(studentsMock));
    }

    [Test]
    public void Ensure_CreateStudent_Works_Properly()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
      dbMock.Setup((db) => db.CreateStudent("Any-Student"));

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
      dbManager.CreateStudent("Any-Student");

      Assert.Pass();
    }
  }
}
