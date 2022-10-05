using NUnit.Framework;
using SchoolManagement.Database;
using System;

namespace SchoolManagement.Tests.Integration
{
  public class GradesModel
  {
    [Test]
    public void Ensure_AddGrade_Works_Properly_With_Invalid_StudentID_Param()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.AddGrade(10, 1, 10),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Invalid StudentID"));
    }

    [Test]
    public void Ensure_AddGrade_Works_Properly_With_Invalid_SubjectID_Param()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.AddGrade(1, 10, 10),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Invalid SubjectID"));
    }
  }
}
