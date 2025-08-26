using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceRecord.Domain;
using AttendanceRecord.Application.Dto;

namespace AttendanceRecord.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext 

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
           public DbSet<Person> Persons { get; set; } // DbSet for Person entity
           public DbSet<Attendance> Attendances { get; set; } // DbSet for Attendance entity
        
    }
}
