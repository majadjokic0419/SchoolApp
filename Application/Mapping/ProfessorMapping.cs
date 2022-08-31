using Application.Service.Dtos.Professor;
using AutoMapper;
using Domain.Models;

namespace Application.Service.Mapping
{
    public class ProfessorMapping : Profile
    {
        public ProfessorMapping()
        {
            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Professor, AddProfessorDto>().ReverseMap();
            CreateMap<Professor, EditProfessorDto>().ReverseMap().AfterMap((src, dest) =>
            { dest.Address = Address.CreateInstance(src.Address.Country, src.Address.City, src.Address.ZipCode, src.Address.Street); }); ;


        }
    }
}
