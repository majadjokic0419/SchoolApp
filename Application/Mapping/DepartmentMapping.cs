using Application.Service.Dtos.Department;
using AutoMapper;
using Domain.Models;

namespace Application.Service.Mapping
{
    public class DepartmentMapping : Profile
    {
        public DepartmentMapping()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, AddDepartmentDto>().ReverseMap();
            CreateMap<Department, EditDepartmentDto>().ReverseMap();

        }
    }
}
