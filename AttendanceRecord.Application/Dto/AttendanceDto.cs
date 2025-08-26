using System;

namespace AttendanceRecord.Application.DTOs
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; } // Nullable because it might be an open record
        public string? Notes { get; set; }
    }
}