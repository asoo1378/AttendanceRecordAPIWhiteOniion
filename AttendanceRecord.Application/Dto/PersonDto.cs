using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecord.Application.Dto
{
    public class PersonDto
    {
        
        public int Id { get; set; } // Primary key

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(50 ,MinimumLength = 4 , ErrorMessage ="The Full Name Most" +
            "between 4 And 50 Carachter.")]
        public string FullName { get; set; } // Full name of the person

        [Required(ErrorMessage = "Employee Code is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "The Employee Code Most" +
            "between 4 And 20 Carachter.")]
        public string EmployeeCode { get; set; } // Unique code for the employee
    }
}