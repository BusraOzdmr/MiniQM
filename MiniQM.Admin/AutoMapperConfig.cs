using AutoMapper.Configuration;
using MiniQM.Admin.Models;
using MiniQM.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniQM.Admin
{
    public class AutoMapperConfig
    {
        public void Initialize()
        {
            var cfg = new MapperConfigurationExpression
            {
                AllowNullCollections = true,
                AllowNullDestinationValues = true
            };
                cfg.CreateMap<Company, CompanyViewModel>().ReverseMap().ForMember(
                dest => dest.QualityPlans, opt => opt.Ignore()).ForMember(
                dest => dest.Facilities, opt => opt.Ignore()).ForMember(
                dest => dest.Departments, opt => opt.Ignore()).ForMember(
                dest => dest.ProductionEquipments, opt => opt.Ignore()).ForMember(
                dest => dest.SystemUsers, opt => opt.Ignore());
            
            cfg.CreateMap<Facility, FacilityViewModel>().ForMember(
            dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ReverseMap().
            ForMember(dest => dest.Company, opt => opt.Ignore()).
            ForMember(dest => dest.QualityPlans, opt => opt.Ignore()).
            ForMember(dest => dest.Departments, opt => opt.Ignore()).
            ForMember(dest => dest.ProductionEquipments, opt => opt.Ignore());

            cfg.CreateMap<Department, DepartmentViewModel>().ForMember(
            dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ForMember(
            dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name)).ReverseMap().
            ForMember(dest => dest.Company, opt => opt.Ignore()).
            ForMember(dest => dest.Facility, opt => opt.Ignore()).
            ForMember(dest => dest.Positions, opt => opt.Ignore()).            
            ForMember(dest => dest.SystemUsers, opt => opt.Ignore());

            cfg.CreateMap<QualityPlan, QualityPlanViewModel>().ForMember(
            dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ForMember(
            dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name)).ForMember(
            dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Name)).ReverseMap().
            ForMember(dest => dest.Company, opt => opt.Ignore()).
            ForMember(dest => dest.Facility, opt => opt.Ignore()).
            ForMember(dest => dest.Material, opt => opt.Ignore()).
            ForMember(dest => dest.ChangeQualityPlans, opt => opt.Ignore());

            cfg.CreateMap<Material, MaterialViewModel>().ReverseMap().ForMember(
                dest => dest.QualityPlans, opt => opt.Ignore()).ForMember(
                dest => dest.ChangeQualityPlans, opt => opt.Ignore());

            cfg.CreateMap<Position, PositionViewModel>().ForMember(
            dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name)).ReverseMap().
            ForMember(dest => dest.Department, opt => opt.Ignore()).
            ForMember(dest => dest.SystemUsers, opt => opt.Ignore());
            


            Mapper.Initialize(cfg);
        }
    }
}