using AttendanceRecord.Application.Interfaces;
using AttendanceRecord.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceRecord.Application.services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _personRepository.Add(person);
            await _personRepository.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _personRepository.Update(person);
            await _personRepository.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person != null)
            {
                _personRepository.Delete(person);
                await _personRepository.SaveChangesAsync();
            }
        }
    }
}