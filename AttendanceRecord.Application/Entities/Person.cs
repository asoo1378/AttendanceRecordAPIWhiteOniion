using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecord.Domain
{
    public class Person
    {
        [Key]
        public int Id { get; set; } // Primary key
        [Required]
        [StringLength(50, MinimumLength =4)]
        public string FullName { get; set; } // Full name of the person
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string EmployeeCode { get; set; } // Unique code for the employee

        public List<Attendance> AttendanceRecords { get; set; }
        = new List<Attendance>();
    }
}
