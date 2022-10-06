using System;
using System.ComponentModel;

namespace SchoolManagement.Models
{
  public class Student : ICloneable
  {
    public int ID { get; set; }

    public string Name { get; set; }

    public Student() { }
    public Student(int id, string name)
    {
      ID = id;
      Name = name;
    }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
