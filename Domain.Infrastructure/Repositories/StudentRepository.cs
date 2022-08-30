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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        readonly private ApplicationDbContext _contex;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _contex=context;
        }
        public async Task Update(Student obj)
        {
            _contex.Students.Update(obj);
        }


    }
}
