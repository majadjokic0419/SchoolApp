using Application.Service.Dtos.Course;
using AutoMapper;
using Domain.Models;

namespace Application.Service.Mapping
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, AddCourseDto>().ReverseMap();
            CreateMap<Course, EditCourseDto>().ReverseMap();

        }
    }
}
