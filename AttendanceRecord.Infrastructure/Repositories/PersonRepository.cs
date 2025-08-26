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
    public class PersonRepository : IPersonRepository
    {
        public readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.Persons.Add(person);
        }


        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var person = await GetByIdAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
         
            return await _context.SaveChangesAsync();
        }



        public void Update(Person person)
        {
            _context.Persons.Update(person);
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
        }


    }
}
