using AttendanceRecord.Application.Dto;
using AttendanceRecord.Application.Interfaces;
using AttendanceRecord.Domain;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceRecord.Application.services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper; 

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;   
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _personRepository.Add(person);
            await _personRepository.SaveChangesAsync();
            return person;
        }



        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            var personEntities = await _personRepository.GetAllAsync();
            var personDtos = _mapper.Map<IEnumerable<PersonDto>>(personEntities);
            return personDtos;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var personEntry = await _personRepository.GetByIdAsync(id);

            if (personEntry == null )
            {
                return null;
            }

            var personDto = _mapper.Map<PersonDto>(personEntry);
            return personEntry;
            
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