using System;
using System.Collections.Generic;

namespace FacultyLife
{
    public class Faculty
    {
        public string Name { get; private set; }
        public List<Student> Students { get; private set; }
        public List<Professor> Professors { get; private set; }

        public Faculty(string name)
        {
            Name = name;
            Students = new List<Student>();
            Professors = new List<Professor>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void AddProfessor(Professor professor)
        {
            Professors.Add(professor);
        }
    }
}
