using Application.Service.Dtos;
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
            CreateMap<Student, AddStudentDto>().ReverseMap().AfterMap((src, dest) =>
            { dest.Address = Address.CreateInstance(src.Address.Country, src.Address.City, src.Address.ZipCode, src.Address.Street); }); ;
            CreateMap<Student, EditStudentDto>().ReverseMap().AfterMap((src, dest) =>
            { dest.Address = Address.CreateInstance(src.Address.Country, src.Address.City, src.Address.ZipCode, src.Address.Street); }); ;


            CreateMap<AddressDto, Address>()
               .ForCtorParam("Country", opt => opt.MapFrom(src => src.Country))
               .ForCtorParam("City", opt => opt.MapFrom(src => src.City))
               .ForCtorParam("Street", opt => opt.MapFrom(src => src.Street))
               .ForCtorParam("ZipCode", opt => opt.MapFrom(src => src.ZipCode));

        }
    }
}
