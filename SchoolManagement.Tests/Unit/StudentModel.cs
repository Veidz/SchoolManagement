using NUnit.Framework;
using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Tests.Unit
{
  public class StudentModel
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
    public void Ensure_CreateStudent_Throws_If_Param_Is_Null()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.CreateStudent(null),
        Throws.Exception
          .TypeOf<ArgumentNullException>()
          .With.Property("ParamName")
          .EqualTo("Name cannot be null"));
    }

    [Test]
    public void Ensure_CreateStudent_Throws_If_Param_Length_Is_Less_Than_3()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.CreateStudent("aa"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Name must be at least 3 characters long"));
    }

    [Test]
    public void Ensure_CreateStudent_Throws_If_Param_Contains_Numbers()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.CreateStudent("aaa123"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Name cannot have numbers"));
    }

    [Test]
    public void Ensure_EditStudent_Throws_If_Param_Is_Null()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.EditStudent(1, null),
        Throws.Exception
          .TypeOf<ArgumentNullException>()
          .With.Property("ParamName")
          .EqualTo("Name cannot be null"));
    }

    [Test]
    public void Ensure_EditStudent_Throws_If_Param_Length_Is_Less_Than_3()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.EditStudent(1, "aa"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Name must be at least 3 characters long"));
    }

    [Test]
    public void Ensure_EditStudent_Throws_If_Param_Contains_Numbers()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.EditStudent(1, "abc123"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Name cannot have numbers"));
    }

    [Test]
    public void Ensure_EditStudent_Throws_If_User_Do_Not_Exist()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
      dbMock.Setup((db) => db.GetStudentById(1)).Returns((Student)null);

      Assert.That(() => dbManager.EditStudent(1, "abc"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("User not found"));
    }
  }
}
