using AttendanceRecord.Application.Interfaces;
using AttendanceRecord.Application.Mappings;
using AttendanceRecord.Application.services;
using AttendanceRecord.Infrastructure.Persistence;
using AttendanceRecord.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registering the DbContext with a connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registering repositories
builder.Services.AddScoped<IPersonRepository , PersonRepository>();
builder.Services.AddScoped<IAttendanceRepository , AttendanceRepository>();

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<AttendanceService>();

// Registering Automapper
builder.Services.AddAutoMapper(typeof(AttendanceRecord.Application.Mappings.MappingProfile));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
