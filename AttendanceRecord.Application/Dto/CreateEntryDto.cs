using System.ComponentModel.DataAnnotations;

namespace AttendanceRecord.Application.DTOs
{
    public class CreateEntryDto
    {
        [Required]
        public int PersonId { get; set; }
    }
}