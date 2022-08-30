using Application.Service;
using Application.Service.Dtos.Course;
using Application.Service.Dtos.Student;
using AutoMapper;
using Domain.Data;
using Domain.Models;
using Domain.Service.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _unitOfWork = unitOfWork;
        }



        public async Task AddCourse(AddCourseDto dto)
        {
           
            Course course = _mapper.Map<Course>(dto);

            await _unitOfWork.CourseRepository.Insert(course);
            await _unitOfWork.Save();
        }

        public async Task DeleteCourse(int id)
        {
            await _unitOfWork.CourseRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<List<CourseDto>> GetAll(int page, int pageResults = 3)
        {
            int pageCount = (_context.Courses.Count() + pageResults - 1) / pageResults;

            var courses = await _context.Courses
                .Skip((page - 1) * pageResults)
                .Take(pageResults).Select(s => _mapper.Map<CourseDto>(s))
                .ToListAsync();
            return courses;
        }

        public async Task<CourseDto> GetById(int id)
        {
            var course = await _context.Courses
               .Select(s => _mapper.Map<CourseDto>(s))
               .FirstOrDefaultAsync(x => x.Id == id);

            if (course is null) throw new NullReferenceException("Course is null");

            return course;

        }

        public async Task UpdateCourse(EditCourseDto dto)
        {
            var courseTemp = await _context.Courses.FindAsync(dto.Id);
            if (courseTemp is null) throw new NullReferenceException("Course is null");

            Course course = _mapper.Map<Course>(dto);

            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.Save();
        }
    }
}
