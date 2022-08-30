using Application.Service.Dtos.Course;
using Application.Service.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAll(int page, int pageResults);
        Task<StudentDto> GetById(int id);
        Task AddStudent(AddStudentDto dto);
        Task UpdateStudent(EditStudentDto dto);
        Task DeleteStudent(int id);
    }
}
