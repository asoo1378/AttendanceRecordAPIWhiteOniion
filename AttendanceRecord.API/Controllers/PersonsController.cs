using AttendanceRecord.Application.Dto;

using AttendanceRecord.Application.services;

using AttendanceRecord.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceRecord.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly IMapper _mapper;

        public PersonsController(PersonService personService, IMapper mapper)
        {
            // اینجا از حرف p کوچک برای پارامتر ورودی استفاده می‌کنیم
            _personService = personService;
            _mapper = mapper;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAllPersons()
        {
            var persons = await _personService.GetAllPersonsAsync();
            var personDtos = _mapper.Map<IEnumerable<PersonDto>>(persons);
            return Ok(personDtos);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPersonById(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound(); // اگه پیدا نشد، خطای 404 برمی‌گردونه
            }

            var personDto = _mapper.Map<PersonDto>(person);
            return Ok(personDto);
        }

       [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            var createdPerson = await _personService.CreatePersonAsync(person); ;

            var createdPersonDto = _mapper.Map<PersonDto>(createdPerson);

            // حالا GetPersonById رو می‌شناسه
            return CreatedAtAction(nameof(GetPersonById),
                new { id = createdPersonDto.Id }, createdPersonDto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonDto personDto)
        {
            if (id != personDto.Id)
            {
                return BadRequest();
            }

            var person = _mapper.Map<Person>(personDto);
            await _personService.UpdatePersonAsync(person);

            return NoContent(); // یعنی عملیات موفق بود و محتوایی برای برگرداندن نیست
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeletePersonAsync(id);

            return NoContent();
        }
    }
}