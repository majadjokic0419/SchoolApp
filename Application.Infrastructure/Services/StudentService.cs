using Application.Service;
using Application.Service.Dtos.Student;
using Application.Service.Mapping;
using AutoMapper;
using Domain.Data;
using Domain.Infrastructure;
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
            Student student = new Student();

            student = _mapper.Map<Student>(dto);

            await _unitOfWork.StudentRepository.Insert(student);
            await _unitOfWork.Save();
        }

        public async Task DeleteStudent(int id)
        {
            await _unitOfWork.StudentRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<List<StudentDto>> GetAll(int page, int pageResults = 3)
        {

            int pageCount = (_context.Students.Count() + pageResults - 1) / pageResults;

            var students = await _context.Students
                .Skip((page - 1) * pageResults)
                .Take(pageResults).Select(s => _mapper.Map<StudentDto>(s))
                .ToListAsync();
            return students;
        }

        public async Task<StudentDto> GetById(int id)
        {

            var student = await _context.Students
                .Select(s => _mapper.Map<StudentDto>(s))
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student is null) throw new NullReferenceException("Student is null");

            return student;

        }

        public async Task UpdateStudent(EditStudentDto dto)
        {
            var studentTemp= await _context.Students.FindAsync(dto.Id);
            if (studentTemp is null) throw new NullReferenceException("Student is null");

            Student student = _mapper.Map<Student>(dto);

           await _unitOfWork.StudentRepository.Update(student);
           await _unitOfWork.Save();
        }
    }
}
