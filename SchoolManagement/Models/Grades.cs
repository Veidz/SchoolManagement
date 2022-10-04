﻿using Org.BouncyCastle.Security;

namespace SchoolManagement.Models
{
  public class Grades
  {
    private int subjectID;
    private string subjectName;
    private float grade;

    public int SubjectID
    {
      get { return subjectID; }
      set
      {
        subjectID = value;
      }
    }

    public string SubjectName
    {
      get { return subjectName; }
      set
      {
        subjectName = value;
      }
    }

    public float Grade
    {
      get { return grade; }
      set
      {
        grade = value;
      }
    }

    public Grades() { }
    public Grades(int subjectID, string subjectName, float grade)
    {
      SubjectID = subjectID;
      SubjectName = subjectName;
      Grade = grade;
    }
  }
}
