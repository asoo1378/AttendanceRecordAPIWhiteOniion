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

        #region Add
        public void Add(Person person)
        {
            _context.Persons.Add(person);
        }


        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region List
        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList(); 
        }
        
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }
        #endregion

        #region Get Id
        public Person GetById( int id)
        {
            return _context.Persons.Find(id);
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }
        #endregion

        #region Update
        public void Update(Person person)
        {
            _context.Persons.Update(person);
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
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
        #endregion


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
         
            return await _context.SaveChangesAsync();
        }


        

    }
}
