

using Domain.Data;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Service.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        readonly private ApplicationDbContext _contex;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _contex = context;
        }

        public async Task AddStudentToCourse(int studentId, int courseId)
        {
            await context.StudentCourses.AddAsync(new StudentCourse { StudentId = studentId, CourseId = courseId });
        }

        public async Task AddProfessorToCourse(int professorId, int courseId)
        {
           await context.ProfessorCourses.AddAsync(new ProfessorCourse { ProfessorId = professorId, CourseId = courseId });
        }

        public async Task Update(Course obj)
        {
            _contex.Courses.Update(obj);
        }
    }
}
