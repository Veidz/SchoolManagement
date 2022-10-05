using NUnit.Framework;
using SchoolManagement.Database;
using SchoolManagement.Protocols;
using System;

namespace SchoolManagement.Tests.Integration
{
  public class StudentModel
  {
    [Test]
    public void Ensure_CreateStudent_Works_Properly_With_Null_Param()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.CreateStudent(null),
        Throws.Exception
          .TypeOf<ArgumentNullException>()
          .With.Property("ParamName")
          .EqualTo("Invalid name"));
    }

    [Test]
    public void Ensure_EditStudent_Works_Properly_With_Null_Param()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.EditStudent(1, null),
        Throws.Exception
          .TypeOf<ArgumentNullException>()
          .With.Property("ParamName")
          .EqualTo("Invalid name"));
    }
  }
}
