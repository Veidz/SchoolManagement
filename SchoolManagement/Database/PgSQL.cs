using MySql.Data.MySqlClient;
using Npgsql;
using SchoolManagement.Models;
using SchoolManagement.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagement.Database
{
  public class PgSQL : IDatabase
  {
    private static readonly string host = "localhost";
    private static readonly string port = "5432";
    private static readonly string user = "postgres";
    private static readonly string password = "root";
    private static readonly string dbname = "school_management";

    private static NpgsqlConnection sqlConnection;

    public PgSQL()
    {
      try
      {
        sqlConnection = new NpgsqlConnection($"Server={host};Port={port};Database={dbname};User Id={user};Password={password}");
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

      NpgsqlCommand getAll = new NpgsqlCommand("SELECT * FROM students;", sqlConnection);
      NpgsqlDataReader reader = getAll.ExecuteReader();
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

      NpgsqlCommand create = new NpgsqlCommand("INSERT INTO students (name) VALUES (@name)", sqlConnection);
      create.Parameters.AddWithValue("@name", name);
      create.ExecuteNonQuery();

      Disconnect();
    }

    public Student GetStudentById(int id)
    {
      Connect();

      NpgsqlCommand getById = new NpgsqlCommand("SELECT * FROM students WHERE ID = @id;", sqlConnection);
      getById.Parameters.AddWithValue("@id", id);

      NpgsqlDataReader reader = getById.ExecuteReader();

      while (reader.Read())
      {
        Student student = new Student()
        {
          ID = reader.GetInt32(0),
          Name = reader.GetString(1)
        };

        Disconnect();
        return student;
      }
      return null;
    }

    public void EditStudent(int id, string name)
    {
      Connect();

      NpgsqlCommand edit = new NpgsqlCommand("UPDATE students SET name = @name WHERE id = @id;", sqlConnection);
      edit.Parameters.AddWithValue("@name", name);
      edit.Parameters.AddWithValue("@id", id);
      edit.ExecuteNonQuery();

      Disconnect();
    }

    public void DeleteStudent(int id)
    {
      Connect();

      NpgsqlCommand remove = new NpgsqlCommand("DELETE FROM students WHERE id = @id;", sqlConnection);
      remove.Parameters.AddWithValue("@id", id);
      remove.ExecuteNonQuery();

      Disconnect();
    }

    public List<Grades> ShowGrades(int id)
    {
      Connect();

      List<Grades> grades = new List<Grades>();

      NpgsqlCommand showCommand = new NpgsqlCommand(@"
        SELECT
          grades.subject_id,
          subjects.name,
          grades.grade
        FROM students
        JOIN grades
        ON students.id = grades.student_id
        JOIN subjects
        ON subjects.id = grades.subject_id
        WHERE students.id = @student_id;",
      sqlConnection);
      showCommand.Parameters.AddWithValue("@student_id", id);

      NpgsqlDataReader reader = showCommand.ExecuteReader();
      while (reader.Read())
      {
        Grades grade = new Grades()
        {
          SubjectID = reader.GetInt32(0),
          SubjectName = reader.GetString(1),
          Grade = reader.GetFloat(2)
        };
        grades.Add(grade);
      }

      Disconnect();
      return grades;
    }

    public void AddGrade(int studentID, int subjectID, float grade)
    {
      Connect();

      NpgsqlCommand add = new NpgsqlCommand("INSERT INTO grades (student_id, subject_id, grade)VALUES (@student_id, @subject_id, @grade);", sqlConnection);
      add.Parameters.AddWithValue("@student_id", studentID);
      add.Parameters.AddWithValue("@subject_id", subjectID);
      add.Parameters.AddWithValue("@grade", grade);
      add.ExecuteNonQuery();

      Disconnect();
    }

    public void EditGrade(int studentID, int subjectID, float grade)
    {
      Connect();

      NpgsqlCommand edit = new NpgsqlCommand("UPDATE grades SET grade = @grade WHERE student_id = @student_id AND subject_id = @subject_id;", sqlConnection);
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
