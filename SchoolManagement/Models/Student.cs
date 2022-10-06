using System;
using System.ComponentModel;

namespace SchoolManagement.Models
{
  public class Student : INotifyPropertyChanged, ICloneable
  {
    private int id;
    private string name;

    public int ID
    {
      get { return id; }
      set
      {
        id = value;
        NotifyPropertyChanged();
      }
    }

    public string Name
    {
      get { return name; }
      set
      {
        name = value;
        NotifyPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public Student() { }
    public Student(int id, string name)
    {
      ID = id;
      Name = name;
    }

    private void NotifyPropertyChanged(string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
