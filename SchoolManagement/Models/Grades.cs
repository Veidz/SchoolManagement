using System;

namespace SchoolManagement.Models
{
  public class Grades : ICloneable
  {
    public int SubjectID { get; set; }

    public string SubjectName { get; set; }

    public float Grade { get; set; }

    public Grades() { }
    public Grades(int subjectID, string subjectName, float grade)
    {
      SubjectID = subjectID;
      SubjectName = subjectName;
      Grade = grade;
    }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
