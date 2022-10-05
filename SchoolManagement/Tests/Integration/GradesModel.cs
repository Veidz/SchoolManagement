using NUnit.Framework;
using SchoolManagement.Database;
using System;

namespace SchoolManagement.Tests.Integration
{
  public class GradesModel
  {
    [Test]
    public void Ensure_AddGrade_Throws_If_Grade_Is_Greater_Than_10()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.AddGrade(1, 1, 11),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Grade cannot be greater than 10"));
    }
  }
}
