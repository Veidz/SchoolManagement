using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Utils;
using SchoolManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.ViewModels
{
  public class MainViewModel
  {
    private readonly DatabaseManager DBManager;
    public ObservableCollection<Student> Students { get; set; }

    public Student SelectedStudent { get; set; }

    public ICommand CreateStudent { get; private set; }
    public ICommand EditStudent { get; private set; }
    public ICommand DeleteStudent { get; private set; }

    public MainViewModel()
    {
      Students = new ObservableCollection<Student>();
      DBManager = new DatabaseManager(new MySQL());

      List<Student> studentList = DBManager.GetAllStudents();
      Students = new ObservableCollection<Student>(studentList);

      StartCommands();
    }

    public void StartCommands()
    {
      CreateStudent = new RelayCommand((param) =>
      {
        Student student = new Student();

        StudentWindow studentWindow = new StudentWindow()
        {
          DataContext = student
        };

        bool? dialogResult = studentWindow.ShowDialog();
        if (dialogResult == true)
        {
          DBManager.CreateStudent(student.Name);

          //Students.Clear();

          List<Student> studentList = DBManager.GetAllStudents();
          Students = new ObservableCollection<Student>(studentList);
        }
      });

      EditStudent = new RelayCommand((param) =>
      {
        StudentWindow studentWindow = new StudentWindow()
        {
          DataContext = SelectedStudent
        };

        bool? dialogResult = studentWindow.ShowDialog();
        if (dialogResult == true)
        {
          DBManager.EditStudent(SelectedStudent.ID, SelectedStudent.Name);

          //Students.Clear();

          List<Student> studentList = DBManager.GetAllStudents();
          Students = new ObservableCollection<Student>(studentList);
        }
      }, param => SelectedStudent != null);

      DeleteStudent = new RelayCommand((param) =>
      {
        DBManager.DeleteStudent(SelectedStudent.ID);

        //Students.Clear();

        List<Student> studentList = DBManager.GetAllStudents();
        Students = new ObservableCollection<Student>(studentList);
      }, param => SelectedStudent != null);
    }
  }
}
