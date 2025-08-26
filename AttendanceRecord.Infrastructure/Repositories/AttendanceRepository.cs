using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecord.Application.Interfaces;
using AttendanceRecord.Infrastructure.Persistence;
using AttendanceRecord.Domain;
using Microsoft.EntityFrameworkCore;

namespace AttendanceRecord.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }


        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await GetByIdAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Attendance?> GetLatestUnfinishedRecordAsync(int personId)
        {
            return await _context.Attendances
                .Where(a => a.PersonId == personId && a.ExitTime == null)
                .OrderByDescending(a => a.EntryTime)
                .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Attendance>> GetByPersonIdAsync(int personId)
        {
            return await _context.Attendances
                .Where(a => a.PersonId == personId)
                .OrderByDescending(a => a.EntryTime)
                .ToListAsync();
        }
    }
}
