using MySql.Data.MySqlClient;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SchoolManagement.Database
{
  public class MySQL : IDatabase
  {
    private static readonly string host = "localhost";
    private static readonly string port = "3307";
    private static readonly string user = "root";
    private static readonly string password = "docker";
    private static readonly string dbname = "school_management";

    private static MySqlConnection sqlConnection;

    public MySQL()
    {
      try
      {
        sqlConnection = new MySqlConnection($"server={host};user={user};database={dbname};port={port};password={password}");
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message);
        throw new Exception("Error connecting to database");
      }
    }

    public List<Student> GetAllStudents()
    {
      Connect();

      List<Student> students = new List<Student>();

      MySqlCommand getAll = new MySqlCommand("SELECT * FROM `school_management`.students;", sqlConnection);
      MySqlDataReader reader = getAll.ExecuteReader();
      while (reader.Read())
      {
        Student student = new Student()
        {
          ID = reader.GetInt32(0),
          Name = reader.GetString(1)
        };
        students.Add(student);
      }

      Disconnect();
      return students;
    }

    public void CreateStudent(string name)
    {
      Connect();

      MySqlCommand create = new MySqlCommand("INSERT INTO `school_management`.students (name) VALUES (@name)", sqlConnection);
      create.Parameters.AddWithValue("@name", name);
      create.ExecuteNonQuery();

      Disconnect();
    }

    public void EditStudent(int id, string name)
    {
      Connect();

      MySqlCommand edit = new MySqlCommand("UPDATE school_management.students SET name = @name WHERE id = @id;", sqlConnection);
      edit.Parameters.AddWithValue("@name", name);
      edit.Parameters.AddWithValue("@id", id);
      edit.ExecuteNonQuery();

      Disconnect();
    }

    public void DeleteStudent(int id)
    {
      Connect();

      MySqlCommand remove = new MySqlCommand("DELETE FROM school_management.students WHERE id = @id;", sqlConnection);
      remove.Parameters.AddWithValue("@id", id);
      remove.ExecuteNonQuery();

      Disconnect();
    }

    public List<Grades> ShowGrades(int id)
    {
      Connect();

      List<Grades> grades = new List<Grades>();

      MySqlCommand showCommand = new MySqlCommand(@"
        SELECT
          grades.subject_id,
          subjects.name,
          grades.grade
        FROM school_management.students
        JOIN school_management.grades
        ON students.id = grades.student_id
        JOIN school_management.subjects
        ON subjects.id = grades.subject_id
        WHERE students.id = @student_id;",
      sqlConnection);
      showCommand.Parameters.AddWithValue("@student_id", id);

      MySqlDataReader reader = showCommand.ExecuteReader();
      while (reader.Read())
      {
        Grades grade = new Grades()
        {
          SubjectID = reader.GetInt32(0),
          SubjectName = reader.GetString(1),
          Grade = reader.GetInt32(2)
        };
        grades.Add(grade);
      }

      Disconnect();
      return grades;
    }

    public void AddGrade(int studentID, int subjectID, float grade)
    {
      Connect();

      MySqlCommand add = new MySqlCommand("INSERT INTO school_management.grades (student_id, subject_id, grade)VALUES (@student_id, @subject_id, @grade);", sqlConnection);
      add.Parameters.AddWithValue("@student_id", studentID);
      add.Parameters.AddWithValue("@subject_id", subjectID);
      add.Parameters.AddWithValue("@grade", grade);
      add.ExecuteNonQuery();

      Disconnect();
    }

    public void EditGrade(int studentID, int subjectID, float grade)
    {
      Connect();

      MySqlCommand edit = new MySqlCommand("UPDATE school_management.grades SET grade = @grade WHERE student_id = @student_id AND subject_id = @subject_id;", sqlConnection);
      edit.Parameters.AddWithValue("@student_id", studentID);
      edit.Parameters.AddWithValue("@subject_id", subjectID);
      edit.Parameters.AddWithValue("@grade", grade);
      edit.ExecuteNonQuery();

      Disconnect();
    }

    private void Connect()
    {
      sqlConnection.Open();
    }

    private void Disconnect()
    {
      sqlConnection.Close();
    }
  }
}
