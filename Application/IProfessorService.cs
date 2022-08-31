using Application.Service.Dtos;
using Application.Service.Dtos.Professor;

namespace Application.Service
{
    public interface IProfessorService
    {
        Task<ResponsePage<ProfessorDto>> GetAll(int page, int pageResults = 3);
        Task<ProfessorDto> GetById(int id);
        Task AddProfessor(AddProfessorDto dto);
        Task UpdateProfessor(int id, EditProfessorDto dto);
        Task DeleteProfessor(int id);
    }
}
