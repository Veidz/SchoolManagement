using SchoolManagement.Models;
using System.Collections.ObjectModel;

namespace SchoolManagement.ViewModels
{
  public class MainViewModel
  {
    public ObservableCollection<Student> Students { get; set; }

    public MainViewModel()
    {
      Students = new ObservableCollection<Student>();

      Student student = new Student()
      {
        ID = 1,
        Name = "Joe Doe"
      };

      Students.Add(student);
    }
  }
}
