using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SchoolManagement.Database
{
  public class DatabaseManager : IDatabase
  {
    readonly IDatabase Database;

    public DatabaseManager(IDatabase database)
    {
      Database = database;
    }

    public List<Student> GetAllStudents()
    {
      return Database.GetAllStudents();
    }

    public void CreateStudent(string name)
    {
      try
      {
        if (name == null) throw new ArgumentNullException("Name cannot be null");
        if (name.Length < 3) throw new Exception("Name must be at least 3 characters long");
        if (Regex.IsMatch(name, @"\d")) throw new Exception("Name cannot have numbers");

        Database.CreateStudent(name);
      }
      catch (Exception exception)
      {
        throw exception;
      }
    }

    public void EditStudent(int id, string name)
    {
      try
      {
        Database.EditStudent(id, name);
      }
      catch (Exception exception)
      {
        if (exception.Message.Contains("null")) throw new ArgumentNullException("Invalid name");
        throw new Exception("Error editing student");
      }
    }

    public void DeleteStudent(int id)
    {
      try
      {
        Database.DeleteStudent(id);
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception.Message);
        throw new Exception("Error deleting student");
      }
    }
  
    public List<Grades> ShowGrades(int id)
    {
      return Database.ShowGrades(id);
    }

    public void AddGrade(int studentID, int subjectID, float grade)
    {
      try
      {
        Database.AddGrade(studentID, subjectID, grade);
      }
      catch (Exception exception)
      {
        if (exception.Message.Contains("student_id")) throw new Exception("Invalid StudentID");
        if (exception.Message.Contains("subject_id")) throw new Exception("Invalid SubjectID");
        throw new Exception("Error adding grade");
      }
    }

    public void EditGrade(int studentID, int subjectID, float grade)
    {
      try
      {
        Database.EditGrade(studentID, subjectID, grade);
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception.Message);
        throw new Exception("Error editing grade");
      }
    }
  }
}
