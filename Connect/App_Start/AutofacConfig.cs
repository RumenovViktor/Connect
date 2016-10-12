using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;

using ApplicationServices;

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
            builder.RegisterType<UserInfoProvider>().As<IUserInfoProvider>();
        }
    }
}
