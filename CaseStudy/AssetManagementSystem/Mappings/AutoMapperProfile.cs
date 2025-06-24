using AssetManagementSystem.DTOs.Asset;
using AssetManagementSystem.DTOs.AssetCategory;
using AssetManagementSystem.DTOs.AuditRequest;
using AssetManagementSystem.DTOs.Employee;
using AssetManagementSystem.DTOs.ServiceRequest;
using AssetManagementSystem.Models;
using AutoMapper;

namespace AssetManagementSystem.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Employee mappings
            CreateMap<Employee, ReadEmployeeDTO>();
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

            // ASSET - Full response for Admins
            CreateMap<Asset, AssetResponseDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.AssetCategory != null ? src.AssetCategory.CategoryName : "Unknown"))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.EmployeeName : null));

            // ASSET - For Create
            CreateMap<CreateAssetDTO, Asset>();

            // ASSET - For Update
            CreateMap<UpdateAssetDTO, Asset>();

            // ASSET - For Employee View (Available only)
            CreateMap<Asset, AssetAvailableDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.AssetCategory != null ? src.AssetCategory.CategoryName : "Unknown"));

            // ASSET - Employees with Assets
            CreateMap<Employee, EmployeeWithAssetsDTO>();

            CreateMap<Asset, AssignedAssetDTO>()
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.AssetCategory != null ? src.AssetCategory.CategoryName : "Unknown"));

            // AssetCategory mappings
            CreateMap<AssetCategory, ReadAssetCategoryDTO>();
            CreateMap<CreateAssetCategoryDTO, AssetCategory>();

            // Service Requests
            CreateMap<ServiceRequest, ReadServiceRequestDTO>()
           .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset != null ? src.Asset.AssetName : "Unknown"))
           .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.EmployeeName : "Unknown"));

            CreateMap<CreateServiceRequestDTO, ServiceRequest>();
            CreateMap<UpdateServiceRequestDTO, ServiceRequest>();

            // AUDIT REQUEST
            CreateMap<AuditRequest, ReadAuditRequestDTO>()
                .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset != null ? src.Asset.AssetName : string.Empty))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.EmployeeName : string.Empty));

            CreateMap<CreateAuditRequestDTO, AuditRequest>();
            CreateMap<UpdateAuditRequestDTO, AuditRequest>();
        }
    }
}
