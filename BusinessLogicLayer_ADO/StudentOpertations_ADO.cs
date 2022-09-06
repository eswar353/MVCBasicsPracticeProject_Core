using System;
using System.Collections.Generic;
using CommonEntities;
using DataAccessLayer_ADO;

namespace BusinessLogicLayer_ADO
{
    public class StudentOpertations_ADO : IStudent
    {
        Studentdata_ADO _studentdata_ado = new Studentdata_ADO();

        public int Add(Student student)
        {
            return _studentdata_ado.Add(student);
        }

        public int Delete(int ID)
        {
            return _studentdata_ado.Delete(ID);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentdata_ado.GetAllStudents();
        }

        public Student GetStudent(int ID)
        {
            return _studentdata_ado.GetStudent(ID);
        }

        public int Update(Student student)
        {
            return _studentdata_ado.Update(student);
        }
    }
}
