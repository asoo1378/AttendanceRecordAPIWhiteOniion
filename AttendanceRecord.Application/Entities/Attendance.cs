using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecord.Domain
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime EntryTime { get; set; } // The time when the person entered
        public DateTime? ExitTime { get; set; } // Nullable to allow for cases where the person has not yet exited
        public int PersonId { get; set; } // Foreign key to Person
      
        [ForeignKey("PersonId")]
        [StringLength(20, MinimumLength =4)]
        public Person Person { get; set; } // Navigation property to Person

        [StringLength(300)]
        public string? Notes { get; set; } // Optional notes about the attendance record

    }
}
