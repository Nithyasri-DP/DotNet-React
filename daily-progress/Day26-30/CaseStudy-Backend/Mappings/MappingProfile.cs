using AutoMapper;
using AssetManagement.DTOs.Asset;
using AssetManagement.DTOs.User;
using AssetManagement.DTOs.Service;
using AssetManagement.DTOs.Audit;
using AssetManagement.DTOs.Category;
using AssetManagement.Models;

namespace AssetManagement.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Asset
            CreateMap<AssetCreateDto, Asset>();
            CreateMap<AssetAssignDto, AssetAssignment>();

            CreateMap<Asset, AssetDetailDto>()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.AssetCategory.CategoryName));

            CreateMap<Asset, AssetAvailableDto>()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.AssetCategory.CategoryName));

            CreateMap<AssetAssignment, AssetAssignDto>()
             .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.AssetName))
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));

            // User
            CreateMap<CreateEmployeeDto, User>();
            CreateMap<User, UserDto>()
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<UpdateEmployeeDto, User>();

            // Service Request
            CreateMap<ServiceRequestDto, ServiceRequest>();
            CreateMap<ServiceUpdateDto, ServiceRequest>();

            // Audit
            CreateMap<AuditRequestDto, AssetAudit>();
            CreateMap<AuditResponseDto, AssetAudit>();

            // Category   
            CreateMap<CategoryCreateDto, AssetCategory>().ReverseMap();
            CreateMap<AssetCategory, CategoryDto>();
        }
    }
}
