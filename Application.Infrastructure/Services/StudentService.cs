using Application.Service;
using Application.Service.Dtos;
using Application.Service.Dtos.Student;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Data;
using Domain.Models;
using Domain.Service.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Services
{
    public class StudentService : IStudentService
    {

        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task AddStudent(AddStudentDto dto)
        {

            Student student = _mapper.Map<Student>(dto);

            await _unitOfWork.StudentRepository.Insert(student);
            await _unitOfWork.Save();
        }

        public async Task DeleteStudent(int id)
        {
            await _unitOfWork.StudentRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<ResponsePage<StudentDto>> GetAll(int page, int pageResults = 3, string? firstName = null, string? lastName = null)
        {
            var query = _context.Students.AsQueryable();

            if (String.IsNullOrWhiteSpace(firstName) == false)
            {
                query = query.Where(x => x.FirstName == firstName);
            }

            if (String.IsNullOrWhiteSpace(lastName) == false)
            {
                query = query.Where(x => x.LastName == lastName);
            }

            int pageCount = (_context.Students.Count() + pageResults - 1) / pageResults;

            var students = await query.ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .Skip((page - 1) * pageResults)
                .Take(pageResults)
                .ToListAsync();

            return new ResponsePage<StudentDto> { Result = students, CurrentPage = page, Pages = (int)pageCount };
        }

        public async Task<StudentDto> GetById(int id)
        {
            var student = await _context.Students
                .Where(x => x.Id == id)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (student is null) throw new NullReferenceException("Student is null");
            return student;

        }

        public async Task UpdateStudent(int id, EditStudentDto dto)
        {
            var studentTemp = await _context.Students.FindAsync(id);
            if (studentTemp is null) throw new NullReferenceException("Student is null");

            Student student = _mapper.Map<Student>(dto);

            await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Save();
        }
    }
}
