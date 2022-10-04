namespace SchoolManagement.Models
{
  public class Grades
  {
    private int subjectID;
    private int grade;

    public int SubjectID
    {
      get { return subjectID; }
      set
      {
        subjectID = value;
      }
    }

    public int Grade
    {
      get { return grade; }
      set
      {
        grade = value;
      }
    }

    public Grades() { }
    public Grades(int subjectID, int grade)
    {
      SubjectID = subjectID;
      Grade = grade;
    }
  }
}
