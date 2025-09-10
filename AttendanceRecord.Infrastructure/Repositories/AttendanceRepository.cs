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
        #region Add
        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region List
        public IEnumerable<Attendance> GetAll()
        {
            return _context.Attendances.ToList();
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync();
        }
        #endregion

        #region Get Id
        public Attendance GetById(int id)
        {
            return _context.Attendances.Find(id);
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }
        #endregion

        #region Update
        public void Update(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
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
        #endregion

        #region Get Last Record
        public Attendance GetLatestUnfinishedRecord(int personId)
        {
            return _context.Attendances
                .Where(a => a.PersonId == personId && a.ExitTime == null)
                .OrderByDescending(a => a.EntryTime)
                .FirstOrDefault();
        }

        public async Task<Attendance?> GetLatestUnfinishedRecordAsync(int personId)
        {
            return await _context.Attendances
                .Where(a => a.PersonId == personId && a.ExitTime == null)
                .OrderByDescending(a => a.EntryTime)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Get By PersonId
        public IEnumerable<Attendance> GetByPersonId(int personId)
        {
            return _context.Attendances
                .Where(a => a.PersonId == personId)
                .OrderByDescending(a => a.EntryTime)
                .ToList();
        }

        public async Task<IEnumerable<Attendance>> GetByPersonIdAsync(int personId)
        {
            return await _context.Attendances
                .Where(a => a.PersonId == personId)
                .OrderByDescending(a => a.EntryTime)
                .ToListAsync();
        }
        #endregion
    }
}
