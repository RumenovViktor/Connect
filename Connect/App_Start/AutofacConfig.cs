using ApplicationServices;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace Connect
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterDependancies(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterDependancies(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrationApplicationService>().As<IRegistrationApplicationService>();
            builder.RegisterType<LoginApplicationService>().As<ILoginApplicationService>();
        }
    }
}
