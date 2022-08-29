using CommonEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    internal  class StudentData : IStudent
    {
        private readonly AppDBContext context;

        public StudentData(AppDBContext context)
        {
            this.context = context;
        }

        public Student Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Update(Student student)
        {
            var studentupdate=context.Students.Attach(student);
            studentupdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return student;
        }

        public Student Delete(int ID)
        {
            Student student=context.Students.Find(ID);
            if(student!=null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students;
        }

        public Student GetStudent(int ID)
        {
            return context.Students.Find(ID); 
        }
    }
}
