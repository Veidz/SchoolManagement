using SchoolManagement.Database;
using SchoolManagement.Models;
using SchoolManagement.Utils;
using SchoolManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagement.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private readonly DatabaseManager DBManager;

    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Student> students;
    public ObservableCollection<Student> Students
    {
      get { return students; }
      set
      {
        students = value;
        NotifyPropertyChanged();
      }
    }

    public Student SelectedStudent { get; set; }

    public ICommand CreateStudent { get; private set; }
    public ICommand EditStudent { get; private set; }
    public ICommand DeleteStudent { get; private set; }

    public MainViewModel()
    {
      DBManager = new DatabaseManager(new MySQL());
      Students = new ObservableCollection<Student>(DBManager.GetAllStudents());

      StartCommands();
    }

    public void StartCommands()
    {
      UserCommands();
    }

    public void UserCommands()
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
          try
          {
            DBManager.CreateStudent(student.Name);

            List<Student> studentList = DBManager.GetAllStudents();
            Students = new ObservableCollection<Student>(studentList);
          }
          catch (Exception exception)
          {
            MessageBox.Show(exception.Message);
          }
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
          try
          {
            DBManager.EditStudent(SelectedStudent.ID, SelectedStudent.Name);

            Students = new ObservableCollection<Student>(DBManager.GetAllStudents());
          }
          catch (Exception exception)
          {
            MessageBox.Show(exception.Message);
          }
        }
      }, param => SelectedStudent != null);

      DeleteStudent = new RelayCommand((param) =>
      {
        DBManager.DeleteStudent(SelectedStudent.ID);

        Students = new ObservableCollection<Student>(DBManager.GetAllStudents());
      }, param => SelectedStudent != null);
    }

    private void NotifyPropertyChanged(string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
