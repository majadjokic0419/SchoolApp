using Application.Service;
using Application.Service.Dtos;
using Application.Service.Dtos.Course;
using Application.Service.Dtos.Student;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public async Task<ResponsePage<CourseDto>> GetAll(int page, int pageResults = 3)
        {
            int pageCount = (_context.Courses.Count() + pageResults - 1) / pageResults;

            var courses = await _context.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .Skip((page - 1) * pageResults)
                .Take(pageResults)
                .ToListAsync();

            return new ResponsePage<CourseDto> { Result = courses, CurrentPage = page, Pages = (int)pageCount };          
        }

        public async Task<CourseDto> GetById(int id)
        {
            var course = await _context.Courses
                .Where(x => x.Id == id)
                .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (course is null) throw new NullReferenceException("Course is null");

            return course;

        }

        public async Task UpdateCourse(int id, EditCourseDto dto)
        {
            var courseTemp = await _context.Courses.FindAsync(id);
            if (courseTemp is null) throw new NullReferenceException("Course is null");

            Course course = _mapper.Map<Course>(dto);

            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.Save();
        }

        public async Task AddStudentToCourse(int studentId, int courseId)
        {
            await _unitOfWork.CourseRepository.AddStudentToCourse(studentId, courseId);
        }

        public async Task AddProfessorToCourse(int professorId, int courseId)
        {
            await _unitOfWork.CourseRepository.AddProfessorToCourse(professorId, courseId);
        }
    }
}
