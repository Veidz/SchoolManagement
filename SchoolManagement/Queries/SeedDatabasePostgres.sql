INSERT INTO students (name)
VALUES
	('Ada Lovelace'),
  ('Alan Turing');

INSERT INTO subjects (name)
VALUES
	('Mathematics'),
  ('Physics'),
  ('Chemistry'),
  ('Biology');

INSERT INTO grades (student_id, subject_id, grade)
VALUES
	(1, 1, 10),
  (1, 2, 7),
  (2, 3, 5),
  (2, 4, 9);
