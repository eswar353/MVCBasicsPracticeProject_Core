using System;
using System.Collections.Generic;
using System.Text;

namespace CommonEntities
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int ID);
        int Add(Student student);
        int Delete(int ID);
        int Update(Student student);
    }

}
