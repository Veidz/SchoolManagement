namespace SchoolManagement.Models
{
  public class Student
  {
    private int id;
    private string name;

    public int ID
    {
      get { return id; }
      set
      {
        id = value;
      }
    }

    public string Name
    {
      get { return name; }
      set
      {
        name = value;
      }
    }

    public Student() { }
    public Student(int id, string name)
    {
      ID = id;
      Name = name;
    }
  }
}
