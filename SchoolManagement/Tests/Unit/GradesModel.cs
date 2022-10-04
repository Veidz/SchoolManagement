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
    public void Ensure_AddGrade_Works_Properly_With_Invalid_Param()
    {
      try
      {
        Moq.Mock<IDatabase> dbMock = new Moq.Mock<IDatabase>();
        dbMock.Setup((db) => db.AddGrade(1, 1, 1)).Throws(new Exception("Error adding grade"));

        DatabaseManager dbManager = new DatabaseManager(dbMock.Object);
        dbManager.AddGrade(1, 1, 1);
      }
      catch (Exception exception)
      {
        Assert.That(exception.Message, Is.EqualTo("Error adding grade"));
      }
    }
  }
}
