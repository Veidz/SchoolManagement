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

    public Student GetStudentById(int id)
    {
      return Database.GetStudentById(id);
    }

    public void CreateStudent(string name)
    {
      if (name == null) throw new ArgumentNullException("Name cannot be null");
      if (name.Length < 3) throw new Exception("Name must be at least 3 characters long");
      if (Regex.IsMatch(name, @"\d")) throw new Exception("Name cannot have numbers");

      Database.CreateStudent(name);
    }

    public void EditStudent(int id, string name)
    {
      if (name == null) throw new ArgumentNullException("Name cannot be null");
      if (name.Length < 3) throw new Exception("Name must be at least 3 characters long");
      if (Regex.IsMatch(name, @"\d")) throw new Exception("Name cannot have numbers");

      Student student = Database.GetStudentById(id);
      if (student == null) throw new Exception("User not found");

      Database.EditStudent(id, name);
    }

    public void DeleteStudent(int id)
    {
      Student student = Database.GetStudentById(id);
      if (student == null) throw new Exception("User not found");

      Database.DeleteStudent(id);
    }

    public List<Grades> ShowGrades(int id)
    {
      return Database.ShowGrades(id);
    }

    public void AddGrade(int studentID, int subjectID, float grade)
    {
      if (grade > 10) throw new Exception("Grade cannot be greater than 10");
      if (grade < 0) throw new Exception("Grade cannot be less than 0");

      Database.AddGrade(studentID, subjectID, grade);
    }

    public void EditGrade(int studentID, int subjectID, float grade)
    {
      if (grade > 10) throw new Exception("Grade cannot be greater than 10");
      if (grade < 0) throw new Exception("Grade cannot be less than 0");
      Database.EditGrade(studentID, subjectID, grade);
    }
  }
}
