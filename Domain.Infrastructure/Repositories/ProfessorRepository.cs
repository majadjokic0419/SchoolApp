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
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        readonly private ApplicationDbContext _contex;

        public ProfessorRepository(ApplicationDbContext context): base(context)
        {
            _contex = context;
        }

        public async Task Update(Professor obj)
        {
            _contex.Professors.Update(obj);
        }
    }
}
