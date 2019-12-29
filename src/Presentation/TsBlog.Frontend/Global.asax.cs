using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TsBlog.Repositories;
using TsBlog.Services;
using TsBlog.AutoMapperConfig;
using System;
using System.Linq;

namespace TsBlog.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacRegister();
            AutoMapperRegister();
        }

        private void AutofacRegister()
        {
            var builder = new ContainerBuilder();

            // Register all controllers in the Mvc Application assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Registered Warehouse Reservoir Service
            //builder.RegisterType<PostRepository>().As<IPostRepository>();

            // Register entities based on interface constraints
            var assembly = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assembly)
                .Where(
                    t => t.GetInterfaces()
                    .Any(i => i.IsAssignableFrom(typeof(IDependency)))
                    )
                .AsImplementedInterfaces()
                .InstancePerDependency();

            // Registration Service Layer Service
            builder.RegisterType<PostService>().As<IPostService>();

            // Registration filter
            builder.RegisterFilterProvider();

            var container = builder.Build();

            // Setting Dependency Injection Parser
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void AutoMapperRegister()
        {
            new AutoMapperStartupTask().Execute();
        }
    }
}