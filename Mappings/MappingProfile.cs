using AutoMapper;
using StudentManagement.Models;

namespace StudentManagement.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Students, StudentDto>()
                .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));

            CreateMap<CreateStudentDto, Students>();
            CreateMap<Students, CreateStudentDto>(); // for editing
        }
    }
}
