using CommonEntities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace DataAccessLayer_ADO
{
    public class Studentdata_ADO
    {
        public Studentdata_ADO()
        {
            //var configbuilder = new ConfigurationBuilder();
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //configbuilder.Properties.Add(path, false);
            //var root = configbuilder.Build();
            //var appsettings = root.GetConnectionString("MVCCRUDwithoutEFContext");
            //sqlConnectionString = appsettings.value;

            //this._configuration = configuration;

            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration _configuration = builder.Build();
            sqlConnectionString = _configuration.GetConnectionString("MVCCRUDwithoutEFContext");
        }
        public string sqlConnectionString { get; set; }

        List<Student> students = new List<Student>();

        public int Update(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("StudentAddOrEdit", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("HallTicketNumber", student.HallTicketNumber);
                cmd.Parameters.AddWithValue("FullName", student.FullName);
                cmd.Parameters.AddWithValue("FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("LastName", student.LastName);
                cmd.Parameters.AddWithValue("MobileNumber", student.MobileNumber);
                cmd.Parameters.AddWithValue("FatherName", student.FatherName);
                cmd.Parameters.AddWithValue("StudentNumber", student.StudentNumber);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Add(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("StudentAddOrEdit", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("HallTicketNumber", student.HallTicketNumber);
                cmd.Parameters.AddWithValue("FullName", student.FullName);
                cmd.Parameters.AddWithValue("FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("LastName", student.LastName);
                cmd.Parameters.AddWithValue("MobileNumber", student.MobileNumber);
                cmd.Parameters.AddWithValue("FatherName", student.FatherName);
                cmd.Parameters.AddWithValue("StudentNumber", student.StudentNumber);
                return cmd.ExecuteNonQuery();
            }

        }

        public IEnumerable<Student> GetAllStudents()
        {

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetAllStudents", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Student student = new Student();
                    student.FullName = dataTable.Rows[i]["FullName"].ToString();
                    student.MobileNumber = dataTable.Rows[i]["MobileNumber"].ToString();
                    student.FatherName = dataTable.Rows[i]["FatherName"].ToString();
                    student.HallTicketNumber = dataTable.Rows[i]["HallTicketNumber"].ToString();
                    student.StudentNumber = (int)dataTable.Rows[i]["StudentNumber"];
                    students.Add(student);
                }
                return students.AsEnumerable<Student>();
            }
        }

        public Student GetStudent(int ID)
        {
            Student student = new Student();
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetStudentByStudentNumber", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("StudentNumber", ID);
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    student.HallTicketNumber = dtbl.Rows[0]["HallTicketNumber"].ToString();
                    student.FullName = dtbl.Rows[0]["FullName"].ToString();
                    student.FirstName = dtbl.Rows[0]["FirstName"].ToString();
                    student.LastName = dtbl.Rows[0]["LastName"].ToString();
                    student.FatherName = dtbl.Rows[0]["FatherName"].ToString();
                    student.MobileNumber = dtbl.Rows[0]["MobileNumber"].ToString();
                    student.StudentNumber = Convert.ToInt32(dtbl.Rows[0]["StudentNumber"]);
                }
                return student;
            }
        }

        public int Delete(int ID)
        {
            using (SqlConnection sqlconnection = new SqlConnection(sqlConnectionString))
            {
                sqlconnection.Open();
                SqlCommand cmd = new SqlCommand("deletestudentbyid", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("studentnumber", ID);
                return cmd.ExecuteNonQuery();
            }

        }
    }

}
