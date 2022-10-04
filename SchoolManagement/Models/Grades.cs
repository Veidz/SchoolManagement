namespace SchoolManagement.Models
{
  public class Grades
  {
    private int subjectID;
    private string subjectName;
    private int grade;

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

    public int Grade
    {
      get { return grade; }
      set
      {
        grade = value;
      }
    }

    public Grades() { }
  }
}
