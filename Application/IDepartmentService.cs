using Application.Service.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAll(int page, int pageResults = 3);
        Task<DepartmentDto> GetById(int id);
        Task<DepartmentDto> GetByName(string name);
        Task AddDepartment(AddDepartmentDto dto);
        Task UpdateDepartment(int id,EditDepartmentDto dto);
        Task DeleteDepartment(int id);
    }
}
