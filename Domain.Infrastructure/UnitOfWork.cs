
using Domain.Data;
using Domain.Service.Abstractions.Repositories;
using Domain.Service.Repositories;

namespace Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
        }
        private ICourseRepository courseRepository;
        private IDepartmentRepository departmentRepository;
        private IProfessorCourseRepository professorCourseRepository;
        private IProfessorRepository professorRepository;
        private IStudentCourseRepository studentCourseRepository;
        private IStudentRepository studentRepository;

        

        public ICourseRepository CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(context);
                }
                return courseRepository;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new DepartmentRepository(context);
                }
                return departmentRepository;
            }
        }

        public IProfessorCourseRepository ProfessorCourseRepository
        {
            get
            {
                if (this.professorCourseRepository == null)
                {
                    this.professorCourseRepository = new ProfessorCourseRepository(context);
                }
                return professorCourseRepository;
            }
        }

        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if (this.professorRepository == null)
                {
                    this.professorRepository = new ProfessorRepository(context);
                }
                return professorRepository;
            }
        }

        public IStudentCourseRepository StudentCourseRepository
        {
            get
            {
                if (this.studentCourseRepository == null)
                {
                    this.studentCourseRepository = new StudentCourseRepository(context);
                }
                return studentCourseRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(context);
                }
                return studentRepository;
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
