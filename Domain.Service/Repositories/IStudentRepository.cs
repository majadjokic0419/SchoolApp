﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task Update(Student obj);
    }
}
