using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Models;

namespace RepositoryDemo.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId);
        }

        public void InsertStudent(Student student)
        {
            if (student.FirstName.Length == 0)
            {
                throw new Exception("First name should not be empty!");
            }
            _context.Students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            _context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}