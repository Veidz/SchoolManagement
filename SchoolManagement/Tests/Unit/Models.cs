using NUnit.Framework;
using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
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
    public void Ensure_CreateStudent_Works_Properly_With_Invalid_Param()
    {
      try
      {
        Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
        dbMock.Setup((db) => db.CreateStudent("Invalid-Student")).Throws(new Exception("Error creating student"));

        DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
        dbManager.CreateStudent("Invalid-Student");
      }
      catch (Exception exception)
      {
        Assert.That(exception.Message, Is.EqualTo("Error creating student"));
      }
    }

    [Test]
    public void Ensure_CreateStudent_Works_Properly_With_Valid_Param()
    {
      try
      {
        Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
        dbMock.Setup((db) => db.CreateStudent("Valid-Student"));

        DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
        dbManager.CreateStudent("Valid-Student");
      }
      catch (Exception exception)
      {
        Assert.That(exception.Message, Is.Not.EqualTo("Error creating student"));
      }
    }

    [Test]
    public void Ensure_EditStudent_Works_Properly_With_Invalid_Param()
    {
      try
      {
        Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
        dbMock.Setup((db) => db.EditStudent(1, "Invalid-Student")).Throws(new Exception("Error editing student"));

        DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
        dbManager.EditStudent(1, "Invalid-Student");
      }
      catch (Exception exception)
      {
        Assert.That(exception.Message, Is.EqualTo("Error editing student"));
      }
    }

    [Test]
    public void Ensure_EditStudent_Works_Properly_With_Valid_Param()
    {
      try
      {
        Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
        dbMock.Setup((db) => db.EditStudent(1, "Valid-Student"));

        DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
        dbManager.EditStudent(1, "Valid-Student");
      }
      catch (Exception exception)
      {
        Assert.That(exception.Message, Is.Not.EqualTo("Error editing student"));
      }
    }

    [Test]
    public void Ensure_DeleteStudent_Works_Properly_With_Invalid_Param()
    {
      try
      {
        Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
        dbMock.Setup((db) => db.DeleteStudent(1)).Throws(new Exception("Error deleting student"));

        DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
        dbManager.DeleteStudent(1);
      }
      catch (Exception exception)
      {
        Assert.That(exception.Message, Is.EqualTo("Error deleting student"));
      }
    }
  }
}
