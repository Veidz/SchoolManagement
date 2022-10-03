﻿using MySql.Data.MySqlClient;
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
    private static readonly string port = "3306";
    private static readonly string user = "root";
    private static readonly string password = "root";
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

      return students;
    }

    public void Connect()
    {
      sqlConnection.Open();
    }

    public void Disconnect()
    {
      sqlConnection.Close();
    }
  }
}
