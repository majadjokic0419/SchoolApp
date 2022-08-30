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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        readonly private ApplicationDbContext _contex;
        public DepartmentRepository(ApplicationDbContext context): base(context)
        {
            _contex = context;
        }

        public async Task Update(Department obj)
        {
            _contex.Departments.Update(obj);
        }
    }
}
