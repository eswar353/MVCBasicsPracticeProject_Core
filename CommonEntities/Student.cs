using System;
using System.ComponentModel.DataAnnotations;

namespace CommonEntities
{
    public class Student
    {
        [Required]
        public string HallTicketNumber { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string FatherName { get; set; }
        public int StudentNumber { get; set; }
    }
}
