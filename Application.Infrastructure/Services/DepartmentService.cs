using Application.Service;
using Application.Service.Dtos.Department;
using AutoMapper;
using Domain.Data;
using Domain.Models;
using Domain.Service.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _unitOfWork = unitOfWork;
        }


        public async Task AddDepartment(AddDepartmentDto dto)
        {
            Department department = _mapper.Map<Department>(dto);

            await _unitOfWork.DepartmentRepository.Insert(department);
            await _unitOfWork.Save();
        }

        public async Task DeleteDepartment(int id)
        {
            await _unitOfWork.DepartmentRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<List<DepartmentDto>> GetAll(int page, int pageResults = 3)
        {
            int pageCount = (_context.Departments.Count() + pageResults - 1) / pageResults;

            var departments = await _context.Departments
                .Skip((page - 1) * pageResults)
                .Take(pageResults).Select(s => _mapper.Map<DepartmentDto>(s))
                .ToListAsync();

            return departments;
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            var department = await _context.Departments
               .Select(s => _mapper.Map<DepartmentDto>(s))
               .FirstOrDefaultAsync(x => x.Id == id);

            if (department is null) throw new NullReferenceException("Department is null");

            return department;

        }

        public async Task UpdateDepartment(EditDepartmentDto dto)
        {
            var departmentTemp = await _context.Departments.FindAsync(dto.Id);
            if (departmentTemp is null) throw new NullReferenceException("Department is null");

            Department department = _mapper.Map<Department>(dto);

            await _unitOfWork.DepartmentRepository.Update(department);
            await _unitOfWork.Save();

        }
    }
}
