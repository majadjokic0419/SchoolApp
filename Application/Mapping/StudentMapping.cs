using Application.Service.Dtos.Student;
using AutoMapper;
using Domain.Models;

namespace Application.Service.Mapping
{
    public class StudentMapping : Profile
    {
        public StudentMapping()
        {

            CreateMap<Student, StudentDto>().ReverseMap(); ;
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, EditStudentDto>().ReverseMap();

        }
    }
}
