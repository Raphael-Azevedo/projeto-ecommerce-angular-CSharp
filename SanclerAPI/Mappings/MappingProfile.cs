using AutoMapper;
using SanclerAPI.Models;
using SanclerAPI.DTO;

namespace SanclerAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile ()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Assessments, CreateAssessmentDTO>().ReverseMap();
            CreateMap<Assessments, ReadAssessmentDTO>().ReverseMap();
            CreateMap<Inventory, CreateInventoryDTO>().ReverseMap();
            CreateMap<Inventory, ReadInventoryDTO>().ReverseMap();
            CreateMap<Comments, CreateCommentDTO>().ReverseMap();
            CreateMap<Comments, ReadCommentDTO>().ReverseMap();
            CreateMap<LoginUserDTO, RegisterUserDTO>().ReverseMap();
        }
    }
}