using Autofac;
using Autofac.Integration.Mvc;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Voyatur
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UserRepository>().As<UserRepository>();
            builder.RegisterType<OrganisationRepository>().As<OrganisationRepository>();
            builder.RegisterType<productImageRepository>().As<productImageRepository>();
            builder.RegisterType<YacthRepository>().As<YacthRepository>();
            builder.RegisterType<TourRepository>().As<TourRepository>();
            builder.RegisterType<YacthRentingsRepository>().As<YacthRentingsRepository>();


            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
