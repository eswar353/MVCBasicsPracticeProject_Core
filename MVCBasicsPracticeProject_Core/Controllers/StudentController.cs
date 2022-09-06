using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCBasicsPracticeProject_Core.Models;
using Microsoft.Data.SqlClient;
using CommonEntities;

namespace MVCBasicsPracticeProject_Core.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStudent _student;

        public StudentController(IConfiguration configuration,IStudent student)
        {
            this._configuration = configuration;
            this._student = student;
        }

        public IActionResult Index()
        {
            //DataTable dataTable = new DataTable();
            //using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MVCCRUDwithoutEFContext")))
            //{
            //    connection.Open();
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter("GetAllStudents", connection);
            //    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    dataAdapter.Fill(dataTable);

            //}
            //return View(dataTable);
            var model=_student.GetAllStudents();
            return View(model);

        }

        public IActionResult AddorEdit(int? id)
        {
            Student studentViewModel = new Student();
            if (id > 0)
            { 
                int ID = (int)id;
                studentViewModel = _student.GetStudent(ID);
            }

            return View(studentViewModel);
           
        }

        [HttpPost]
        public IActionResult AddorEdit( [Bind("StudentNumber,HallTicketNumber,FullName,FirstName,LastName,MobileNumber,FatherName")] Student studentViewModel)
        {
            if(ModelState.IsValid)
            {
                //using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("MVCCRUDwithoutEFContext")))
                //{
                //    sqlConnection.Open();
                //    SqlCommand cmd = new SqlCommand("StudentAddOrEdit",sqlConnection);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("HallTicketNumber", studentViewModel.HallTicketNumber);
                //    cmd.Parameters.AddWithValue("FullName", studentViewModel.FullName);
                //    cmd.Parameters.AddWithValue("FirstName", studentViewModel.FirstName);
                //    cmd.Parameters.AddWithValue("LastName", studentViewModel.LastName);
                //    cmd.Parameters.AddWithValue("MobileNumber", studentViewModel.MobileNumber);
                //    cmd.Parameters.AddWithValue("FatherName", studentViewModel.FatherName);
                //    cmd.Parameters.AddWithValue("StudentNumber", studentViewModel.StudentNumber);
                //    cmd.ExecuteNonQuery();
                //}

                if(studentViewModel.StudentNumber > 0)
                {
                    _student.Update(studentViewModel);
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    _student.Add(studentViewModel);
                    return RedirectToAction(nameof(Index));
                }
               
            }

            return View(studentViewModel);
        }

        public IActionResult Delete(int? id)
        {
            int ID = (int)id;
            Student studentViewModel = _student.GetStudent(ID);
            return View(studentViewModel);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //using(SqlConnection sqlConnection=new SqlConnection(_configuration.GetConnectionString("MVCCRUDwithoutEFContext")))
            //{
            //    sqlConnection.Open();
            //    SqlCommand cmd = new SqlCommand("DeleteStudentbyID", sqlConnection);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("StudentNumber",id);
            //    cmd.ExecuteNonQuery();
            //}
            _student.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        [NonAction]
        public Student FetchBookByID(int? id)
        {
            Student studentViewModel = new Student();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("MVCCRUDwithoutEFContext")))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetStudentByStudentNumber", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("StudentNumber", id);
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    studentViewModel.HallTicketNumber = dtbl.Rows[0]["HallTicketNumber"].ToString();
                    studentViewModel.FullName = dtbl.Rows[0]["FullName"].ToString();
                    studentViewModel.FirstName = dtbl.Rows[0]["FirstName"].ToString();
                    studentViewModel.LastName = dtbl.Rows[0]["LastName"].ToString();
                    studentViewModel.FatherName = dtbl.Rows[0]["FatherName"].ToString();
                    studentViewModel.MobileNumber = dtbl.Rows[0]["MobileNumber"].ToString();
                    studentViewModel.StudentNumber = Convert.ToInt32(dtbl.Rows[0]["StudentNumber"]);
                }
                return studentViewModel;
            }
        }
    }
}
