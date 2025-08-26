using System.ComponentModel.DataAnnotations;

namespace AttendanceRecord.Application.DTOs
{
    public class RecordExitDto
    {
        [Required]
        public int PersonId { get; set; }
    }
}