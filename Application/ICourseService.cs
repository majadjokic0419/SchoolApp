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
        Task<List<CourseDto>> GetAll(int page, int pageResults);
        Task AddCourse(AddCourseDto dto);
        Task<CourseDto> GetById(int id);
        Task UpdateCourse(EditCourseDto dto);
        Task DeleteCourse(int id);
    }
}
