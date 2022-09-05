using System;
using System.Collections.Generic;
using CommonEntities;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class StudentOpertations : IStudent
    {
        public AppDBContext contextoperations;
       
        
        public StudentOpertations(AppDBContext contextoperations)
        {
            this.contextoperations = contextoperations;
        }

        
        public Student Add(Student student)
        {

            StudentData _studentData = new StudentData(contextoperations);
            return _studentData.Add(student);
        }

        public Student Delete(int ID)
        {
            StudentData _studentData = new StudentData(contextoperations);
            return _studentData.Delete(ID);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            StudentData _studentData = new StudentData(contextoperations);
            return _studentData.GetAllStudents();
        }

        public Student GetStudent(int ID)
        {
            StudentData _studentData = new StudentData(contextoperations);
            return _studentData.GetStudent(ID);
        }

        public Student Update(Student student)
        {
            StudentData _studentData = new StudentData(contextoperations);
            return _studentData.Update(student);
        }
    }
}
