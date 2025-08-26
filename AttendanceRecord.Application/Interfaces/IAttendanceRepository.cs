using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecord.Domain;

namespace AttendanceRecord.Application.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetByIdAsync(int id); // Get by Id 
        Task<IEnumerable<Attendance>> GetAllAsync(); // Get all attendaces
        Task AddAsync(Attendance attendance); // Add by entity
        Task UpdateAsync(Attendance attendance); // Update by entity
        Task DeleteAsync(int id); // Delete by Id

        Task<Attendance?> GetLatestUnfinishedRecordAsync(int personId); 
        Task<IEnumerable<Attendance>> GetByPersonIdAsync(int personId);



    }
}
