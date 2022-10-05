using NUnit.Framework;
using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Tests.Unit
{
  public class GradesModel
  {
    [Test]
    public void Ensure_ShowGrades_Works_Properly()
    {

      Grades gradeMock = new Grades()
      {
        SubjectID = 1,
        SubjectName = "Mathematics",
        Grade = 10
      };

      List<Grades> gradesMock = new List<Grades>()
      {
        gradeMock
      };

      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
      dbMock.Setup((db) => db.ShowGrades(1)).Returns(gradesMock);

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
      List<Grades> grades = dbManager.ShowGrades(1);

      Assert.That(grades, Is.EqualTo(gradesMock));
    }

    [Test]
    public void Ensure_AddGrade_Throws_If_Grade_Is_Greater_Than_10()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.AddGrade(1, 1, 11),
      Throws.Exception
        .TypeOf<Exception>()
        .With.Property("Message")
        .EqualTo("Grade cannot be greater than 10"));
    }

    [Test]
    public void Ensure_AddGrade_Throws_If_Grade_Is_Less_Than_0()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.AddGrade(1, 1, -1),
      Throws.Exception
        .TypeOf<Exception>()
        .With.Property("Message")
        .EqualTo("Grade cannot be less than 0"));
    }

    [Test]
    public void Ensure_EditGrade_Throws_If_Grade_Is_Greater_Than_10()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.EditGrade(1, 1, 11),
      Throws.Exception
        .TypeOf<Exception>()
        .With.Property("Message")
        .EqualTo("Grade cannot be greater than 10"));
    }

    [Test]
    public void Ensure_Edit_Throws_If_Grade_Is_Less_Than_0()
    {
      Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();

      DatabaseManager dbManager = new DatabaseManager(dbMock.Object);

      Assert.That(() => dbManager.EditGrade(1, 1, -1),
      Throws.Exception
        .TypeOf<Exception>()
        .With.Property("Message")
        .EqualTo("Grade cannot be less than 0"));
    }
  }
}
