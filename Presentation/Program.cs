using Application.Infrastructure.Services;
using Application.Service;
using Application.Service.Dtos.Student;
using Application.Service.Mapping;
using AutoMapper;
using Domain.Data;
using Domain.Infrastructure;
using Domain.Models;
using Domain.Service.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(StudentMapping).Assembly, typeof(CourseMapping).Assembly, typeof(ProfessorMapping).Assembly, typeof(DepartmentMapping).Assembly);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();

