using NUnit.Framework;
using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
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
  }
}
