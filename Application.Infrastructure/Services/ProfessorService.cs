using Application.Service;
using Application.Service.Dtos;
using Application.Service.Dtos.Department;
using Application.Service.Dtos.Professor;
using Application.Service.Dtos.Student;
using AutoMapper;
using Domain.Data;
using Domain.Infrastructure;
using Domain.Models;
using Domain.Service.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public ProfessorService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task AddProfessor(AddProfessorDto dto)
        {
            Professor professor = _mapper.Map<Professor>(dto);

            await _unitOfWork.ProfessorRepository.Insert(professor);
            await _unitOfWork.Save();

        }

        public async Task DeleteProfessor(int id)
        {
            await _unitOfWork.ProfessorRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<ResponsePage<ProfessorDto>> GetAll(int page, int pageResults = 3)
        {
            int pageCount = (_context.Professors.Count() + pageResults - 1) / pageResults;

            var professors = await _context.Professors
                .Skip((page - 1) * pageResults)
                .Take(pageResults).Select(s => _mapper.Map<ProfessorDto>(s))
                .ToListAsync();

            return new ResponsePage<ProfessorDto> { Result = professors, CurrentPage = page, Pages = (int)pageCount };
        }

        public async Task<ProfessorDto> GetById(int id)
        {
            var professor = await _context.Professors
               .Select(s => _mapper.Map<ProfessorDto>(s))
               .FirstOrDefaultAsync(x => x.Id == id);

            if (professor is null) throw new NullReferenceException("Professor is null");

            return professor;

        }

        public async Task UpdateProfessor(int id, EditProfessorDto dto)
        {
            var professorTemp = await _context.Professors.FindAsync(id);
            if (professorTemp is null) throw new NullReferenceException("Professor is null");

            Professor professor = _mapper.Map<Professor>(dto);

            await _unitOfWork.ProfessorRepository.Update(professor);
            await _unitOfWork.Save();

        }
    }
}
