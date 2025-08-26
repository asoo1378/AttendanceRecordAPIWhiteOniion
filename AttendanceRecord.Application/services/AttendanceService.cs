using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecord.Application.Interfaces;
using AttendanceRecord.Domain;

namespace AttendanceRecord.Application.services
{
    public class AttendanceService
    {
        public readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task RecordEntryAsync(int personId) 
        {
            var NewAttendanceRecord = new Attendance
            {
                PersonId = personId, // Assuming PersonId is the ID of the person entering
                EntryTime = DateTime.Now, // Record the current time as entry time     
            };

            await _attendanceRepository.AddAsync(NewAttendanceRecord);
        }


        public async Task RecordExitAsync(int personId)
        {
           
            var attendanceRecord = await _attendanceRepository.GetLatestUnfinishedRecordAsync(personId);

            
            if (attendanceRecord != null)
            {
          
                attendanceRecord.ExitTime = DateTime.Now;

                await _attendanceRepository.UpdateAsync(attendanceRecord);
            }
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByPersonIdAsync(int personId)
        {
            return await _attendanceRepository.GetByPersonIdAsync(personId);
        }

    }
}
