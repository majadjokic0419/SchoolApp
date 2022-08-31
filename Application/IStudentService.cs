using Application.Service.Dtos;
using Application.Service.Dtos.Student;

namespace Application.Service
{
    public interface IStudentService
    {
        Task<ResponsePage<StudentDto>> GetAll(int page, int pageResults = 3, string? firstName = null, string? lastName = null);
        Task<StudentDto> GetById(int id);
        Task AddStudent(AddStudentDto dto);
        Task UpdateStudent(int id, EditStudentDto dto);
        Task DeleteStudent(int id);
    }
}
