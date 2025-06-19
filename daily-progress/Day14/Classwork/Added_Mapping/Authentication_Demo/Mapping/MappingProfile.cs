using Authentication_Demo.DTOs;
using Authentication_Demo.Models;
using AutoMapper;

namespace Authentication_Demo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // For GET/VIEW - bi-directional mapping
            CreateMap<Product, ProductDTO>().ReverseMap();

            // For CREATE - explicitly ignore properties 
            CreateMap<ProductCreationDTO, Product>()
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

            // For UPDATE - assuming ProductUpdateDTO includes IsActive
            CreateMap<ProductUpdateDTO, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        }
    }
}
