﻿using NUnit.Framework;
using SchoolManagement.Database;
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
  }
}
