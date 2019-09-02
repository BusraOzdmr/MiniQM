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
                dest => dest.SystemUsers, opt => opt.Ignore()).
                ForMember(dest => dest.Orders, opt => opt.Ignore()).
                ForMember(dest => dest.PurchasingDepartments, opt => opt.Ignore()).
                ForMember(dest => dest.Suppliers, opt => opt.Ignore()).
                ForMember(dest => dest.StockLocations, opt => opt.Ignore());

            cfg.CreateMap<Facility, FacilityViewModel>().ForMember(
            dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ReverseMap().
            ForMember(dest => dest.Company, opt => opt.Ignore()).
            ForMember(dest => dest.QualityPlans, opt => opt.Ignore()).
            ForMember(dest => dest.Departments, opt => opt.Ignore()).
            ForMember(dest => dest.ProductionEquipments, opt => opt.Ignore()).
            ForMember(dest => dest.Orders, opt => opt.Ignore()).
            ForMember(dest => dest.StockLocations, opt => opt.Ignore());

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
                dest => dest.ChangeQualityPlans, opt => opt.Ignore()).
                ForMember(dest => dest.MaterialInputs, opt => opt.Ignore());

            cfg.CreateMap<Position, PositionViewModel>().ForMember(
            dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name)).ReverseMap().
            ForMember(dest => dest.Department, opt => opt.Ignore()).
            ForMember(dest => dest.SystemUsers, opt => opt.Ignore());

            cfg.CreateMap<SystemUser, SystemUserViewModel>().ForMember(
            dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ForMember(
            dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name)).ForMember(
            dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name)).ReverseMap().
            ForMember(dest => dest.Company, opt => opt.Ignore()).
            ForMember(dest => dest.Department, opt => opt.Ignore()).
            ForMember(dest => dest.Position, opt => opt.Ignore()).
            ForMember(dest => dest.Criterions, opt => opt.Ignore());

            cfg.CreateMap<UserGroup, UserGroupViewModel>().ForMember(
            dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language.Code)).ReverseMap().
            ForMember(dest => dest.Language, opt => opt.Ignore()).
            ForMember(dest => dest.Criterions, opt => opt.Ignore());

            cfg.CreateMap<Language, LanguageViewModel>().ReverseMap().
            ForMember(dest => dest.ProductionEquipments, opt => opt.Ignore()).
            ForMember(dest => dest.Units, opt => opt.Ignore()).
            ForMember(dest => dest.UserGroups, opt => opt.Ignore());

            cfg.CreateMap<ChangeQualityPlan, ChangeQualityPlanViewModel>().ForMember(
           dest => dest.QualityPlanId, opt => opt.MapFrom(src => src.QualityPlan.Id)).ForMember(
           dest => dest.MaterialId, opt => opt.MapFrom(src => src.Material.Id)).ForMember(
           dest => dest.CriterionName, opt => opt.MapFrom(src => src.Criterion.Name)).ForMember(
           dest => dest.CertificateName, opt => opt.MapFrom(src => src.Certificate.Name)).ForMember(
           dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name)).ForMember(
           dest => dest.ProductionEquipmentName, opt => opt.MapFrom(src => src.ProductionEquipment.Name)).ReverseMap().
           ForMember(dest => dest.QualityPlan, opt => opt.Ignore()).
           ForMember(dest => dest.Material, opt => opt.Ignore()).
           ForMember(dest => dest.Criterion, opt => opt.Ignore()).
           ForMember(dest => dest.Certificate, opt => opt.Ignore()).
           ForMember(dest => dest.Unit, opt => opt.Ignore()).
           ForMember(dest => dest.ProductionEquipment, opt => opt.Ignore());

            cfg.CreateMap<Certificate, CertificateViewModel>().ReverseMap().
            ForMember(dest => dest.ChangeQualityPlans, opt => opt.Ignore()).
            ForMember(dest => dest.Criterions, opt => opt.Ignore());

           cfg.CreateMap<Unit, UnitViewModel>().ForMember(
           dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language.Code)).ReverseMap().
           ForMember(dest => dest.Language, opt => opt.Ignore()).
           ForMember(dest => dest.Criterions, opt => opt.Ignore()).
           ForMember(dest => dest.ChangeQualityPlans, opt => opt.Ignore());

           cfg.CreateMap<ProductionEquipment, ProductionEquipmentViewModel>().ForMember(
           dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language.Code)).ForMember(
           dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ForMember(
           dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name)).ReverseMap().
           ForMember(dest => dest.Language, opt => opt.Ignore()).
           ForMember(dest => dest.Company, opt => opt.Ignore()).
           ForMember(dest => dest.Facility, opt => opt.Ignore()).
           ForMember(dest => dest.Criterions, opt => opt.Ignore()).
           ForMember(dest => dest.ChangeQualityPlans, opt => opt.Ignore());

           cfg.CreateMap<Criterion, CriterionViewModel>().ForMember(
           dest => dest.CertificateName, opt => opt.MapFrom(src => src.Certificate.Name)).ForMember(
           dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name)).ForMember(
           dest => dest.SystemUserUserName, opt => opt.MapFrom(src => src.SystemUser.UserName)).ForMember(
           dest => dest.UserGroupName, opt => opt.MapFrom(src => src.UserGroup.Name)).ForMember(
           dest => dest.ProductionEquipmentName, opt => opt.MapFrom(src => src.ProductionEquipment.Name)).ReverseMap().
           ForMember(dest => dest.Certificate, opt => opt.Ignore()).
           ForMember(dest => dest.Unit, opt => opt.Ignore()).
           ForMember(dest => dest.ProductionEquipment, opt => opt.Ignore()).
           ForMember(dest => dest.SystemUser, opt => opt.Ignore()).
           ForMember(dest => dest.UserGroup, opt => opt.Ignore()).
           ForMember(dest => dest.ChangeQualityPlans, opt => opt.Ignore());

            Mapper.Initialize(cfg);
        }
    }
}