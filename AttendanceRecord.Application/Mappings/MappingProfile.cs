using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecord.Application.Dto;
using AttendanceRecord.Application.DTOs;
using AttendanceRecord.Domain;
using AutoMapper;
using System.Reflection;

namespace AttendanceRecord.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {



            var assembly = Assembly.GetExecutingAssembly();

            var DtoTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("Dto"));

            foreach (var DtoType in DtoTypes)
            {
                var EntitesTypeName = DtoType.Name.Replace("Dto", "");
                var EntitesType = assembly.GetTypes().FirstOrDefault(t => t.Name == EntitesTypeName);

                if (EntitesType != null)
                {

                    CreateMap(EntitesType, DtoType);

                }
            }





        }
    } 
}
