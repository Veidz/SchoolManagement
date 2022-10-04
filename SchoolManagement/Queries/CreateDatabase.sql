DROP DATABASE IF EXISTS `school_management`;
CREATE DATABASE IF NOT EXISTS `school_management`;

USE `school_management`;

CREATE TABLE IF NOT EXISTS students (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(50) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS subjects (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(50) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS grades (
  id INT NOT NULL AUTO_INCREMENT,
  student_id INT,
  subject_id INT,
  grade FLOAT(2) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (student_id) REFERENCES students(id) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY (subject_id) REFERENCES subjects(id) ON DELETE CASCADE ON UPDATE CASCADE
);
