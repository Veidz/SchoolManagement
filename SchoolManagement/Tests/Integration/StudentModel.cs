﻿using NUnit.Framework;
using SchoolManagement.Database;
using System;

namespace SchoolManagement.Tests.Integration
{
  public class StudentModel
  {
    [Test]
    public void Ensure_CreateStudent_Throws_If_Param_Is_Null()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.CreateStudent(null),
        Throws.Exception
          .TypeOf<ArgumentNullException>()
          .With.Property("ParamName")
          .EqualTo("Name cannot be null"));
    }

    [Test]
    public void Ensure_CreateStudent_Throws_If_Param_Length_Is_Less_Than_3()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.CreateStudent("aa"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Name must be at least 3 characters long"));
    }

    [Test]
    public void Ensure_CreateStudent_Throws_If_Param_Contains_Numbers()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.CreateStudent("abc123"),
        Throws.Exception
          .TypeOf<Exception>()
          .With.Property("Message")
          .EqualTo("Name cannot have numbers"));
    }

    [Test]
    public void Ensure_EditStudent_Throws_If_Param_Is_Null()
    {
      DatabaseManager dbManager = new DatabaseManager(new MySQL());

      Assert.That(() => dbManager.EditStudent(1, null),
        Throws.Exception
          .TypeOf<ArgumentNullException>()
          .With.Property("ParamName")
          .EqualTo("Name cannot be null"));
    }
  }
}
