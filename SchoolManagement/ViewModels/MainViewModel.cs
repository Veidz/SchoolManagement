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
  public class MainViewModel : BaseViewModel
  {
    private readonly DatabaseManager DBManager;

    private ObservableCollection<Student> students;
    private ObservableCollection<Grades> grades;

    private Student selectedStudent;

    public ObservableCollection<Student> Students
    {
      get { return students; }
      set
      {
        students = value;
        NotifyPropertyChanged();
      }
    }

    public ObservableCollection<Grades> Grades
    {
      get { return grades; }
      set
      {
        grades = value;
        NotifyPropertyChanged();
      }
    }

    public Student SelectedStudent
    {
      get { return selectedStudent; }
      set
      {
        selectedStudent = value;

        if (SelectedStudent != null)
        {
          Grades = new ObservableCollection<Grades>(DBManager.ShowGrades(SelectedStudent.ID));
        }
      }
    }
    public Grades SelectedGrade { get; set; }

    public ICommand CreateStudent { get; private set; }
    public ICommand EditStudent { get; private set; }
    public ICommand DeleteStudent { get; private set; }

    public ICommand AddGrade { get; private set; }
    public ICommand EditGrade { get; private set; }

    public MainViewModel()
    {
      DBManager = new DatabaseManager(new MySQL());
      Students = new ObservableCollection<Student>(DBManager.GetAllStudents());
      Grades = new ObservableCollection<Grades>();

      StartCommands();
    }

    public void StartCommands()
    {
      UserCommands();
      GradeCommands();
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
        Student studentClone = (Student)SelectedStudent.Clone();

        StudentWindow studentWindow = new StudentWindow()
        {
          DataContext = studentClone
        };

        bool? dialogResult = studentWindow.ShowDialog();
        if (dialogResult == true)
        {
          try
          {
            DBManager.EditStudent(SelectedStudent.ID, studentClone.Name);

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

        Grades.Clear();

        Students = new ObservableCollection<Student>(DBManager.GetAllStudents());
      }, param => SelectedStudent != null);
    }

    public void GradeCommands()
    {
      AddGrade = new RelayCommand((param) =>
      {
        Grades grade = new Grades();

        GradeWindow gradeWindow = new GradeWindow()
        {
          DataContext = grade
        };

        bool? dialogResult = gradeWindow.ShowDialog();
        if (dialogResult == true)
        {
          try
          {
            DBManager.AddGrade(SelectedStudent.ID, grade.SubjectID, grade.Grade);

            Grades = new ObservableCollection<Grades>(DBManager.ShowGrades(SelectedStudent.ID));
          }
          catch (Exception exception)
          {
            MessageBox.Show(exception.Message);
          }
        }
      }, param => SelectedStudent != null);

      EditGrade = new RelayCommand((param) =>
      {
        Grades gradeClone = (Grades)SelectedGrade.Clone();

        GradeWindow gradeWindow = new GradeWindow()
        {
          DataContext = gradeClone
        };

        bool? dialogResult = gradeWindow.ShowDialog();
        if (dialogResult == true)
        {
          try
          {
            DBManager.EditGrade(SelectedStudent.ID, SelectedGrade.SubjectID, gradeClone.Grade);

            Grades = new ObservableCollection<Grades>(DBManager.ShowGrades(SelectedStudent.ID));
          }
          catch (Exception exception)
          {
            MessageBox.Show(exception.Message);
          }
        }
      }, param => SelectedGrade != null);
    }
  }
}
