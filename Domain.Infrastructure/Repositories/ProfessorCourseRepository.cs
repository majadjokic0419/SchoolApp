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
    public class ProfessorCourseRepository : GenericRepository<ProfessorCourse>, IProfessorCourseRepository
    {
        public ProfessorCourseRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
