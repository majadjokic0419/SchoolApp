using Application.Service.Dtos;
using Application.Service.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface ICourseService
    {
        Task<ResponsePage<CourseDto>> GetAll(int page, int pageResults = 3);
        public Task AddStudentToCourse(int studentId, int courseId);
        public Task AddProfessorToCourse(int professorId, int courseId);
        Task AddCourse(AddCourseDto dto);
        Task<CourseDto> GetById(int id);
        Task UpdateCourse(int id, EditCourseDto dto);
        Task DeleteCourse(int id);
    }
}
