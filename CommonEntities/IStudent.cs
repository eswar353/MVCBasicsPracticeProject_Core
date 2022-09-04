using System;
using System.Collections.Generic;
using System.Text;

namespace CommonEntities
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int ID);
        Student Add(Student student);
        Student Delete(int ID);

        Student Update(Student student);
    }

}
