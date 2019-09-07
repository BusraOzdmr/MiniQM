using Autofac;
using Autofac.Integration.Mvc;
using MiniQM.Data;
using MiniQM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MiniQM.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<FacilityService>().As<IFacilityService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<QualityPlanService>().As<IQualityPlanService>();
            builder.RegisterType<MaterialService>().As<IMaterialService>();
            builder.RegisterType<PositionService>().As<IPositionService>();
            builder.RegisterType<SystemUserService>().As<ISystemUserService>();
            builder.RegisterType<UserGroupService>().As<IUserGroupService>();
            builder.RegisterType<LanguageService>().As<ILanguageService>();
            builder.RegisterType<ChangeQualityPlanService>().As<IChangeQualityPlanService>();
            builder.RegisterType<CertificateService>().As<ICertificateService>();
            builder.RegisterType<UnitService>().As<IUnitService>();
            builder.RegisterType<ProductionEquipmentService>().As<IProductionEquipmentService>();
            builder.RegisterType<CriterionService>().As<ICriterionService>();
            builder.RegisterType<MaterialInputService>().As<IMaterialInputService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderTypeService>().As<IOrderTypeService>();
            builder.RegisterType<PurchasingDepartmentService>().As<IPurchasingDepartmentService>();
            builder.RegisterType<SupplierService>().As<ISupplierService>();
            builder.RegisterType<BusinessAreaService>().As<IBusinessAreaService>();
            builder.RegisterType<StockLocationService>().As<IStockLocationService>();
            builder.RegisterType<SectorService>().As<ISectorService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            new AutoMapperConfig().Initialize();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
