using AttendanceRecord.Application.DTOs;
using AttendanceRecord.Application.services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AttendanceRecord.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public AttendancesController(AttendanceService attendanceService, IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }


       
        [HttpPost("entry")]
        public async Task<IActionResult> RecordEntry([FromBody] CreateEntryDto createEntryDto)
        {
            
            await _attendanceService.RecordEntryAsync(createEntryDto.PersonId);

            
            return Ok(new { message = "Entry successfully registered." });
        }

        
        [HttpPut("exit")]
        public async Task<IActionResult> RecordExit([FromBody] RecordExitDto recordExitDto)
        {
            await _attendanceService.RecordExitAsync(recordExitDto.PersonId);
            return Ok(new { message = "Exit successfully registered." });
        }

       
        [HttpGet("person/{personId}")]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAttendancesByPersonId(int personId)
        {
            var attendances = await _attendanceService.GetAttendancesByPersonIdAsync(personId);
            var attendanceDtos = _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
            return Ok(attendanceDtos);
        }

    }
}