using Application.Service.Dtos.Professor;
using Application.Service.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
   public interface IProfessorService
    {
        Task<List<ProfessorDto>> GetAll(int page, int pageResults);
        Task<ProfessorDto> GetById(int id);
        Task AddProfessor(AddProfessorDto dto);
        Task UpdateProfessor(EditProfessorDto dto);
        Task DeleteProfessor(int id);
    }
}
