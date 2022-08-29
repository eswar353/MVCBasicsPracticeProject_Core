using CommonEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    internal interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int ID);
        Student Add(Student student);
        Student Delete(int ID);

        Student Update(Student student);



    }
}
