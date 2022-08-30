using Domain.Models;
using Domain.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Abstractions.Repositories
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        public Task Update(Professor obj);
    }
}
