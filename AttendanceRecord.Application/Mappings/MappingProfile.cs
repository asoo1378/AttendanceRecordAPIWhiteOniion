using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecord.Application.Dto;
using AttendanceRecord.Application.DTOs;
using AttendanceRecord.Domain;
using AutoMapper;

namespace AttendanceRecord.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Attendance, AttendanceDto>();
        }

        
    }

   
}
