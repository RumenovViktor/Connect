using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;

using ApplicationServices;
using Data.Unit_Of_Work;
using Data.DataContext;

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
            builder.RegisterType<DALServiceDataContext>().As<IDALServiceDataContext>();
            builder.RegisterType<DALServiceData>().As<IDALServiceData>();
            builder.RegisterType<LoginApplicationService>().As<ILoginApplicationService>();
            builder.RegisterType<UserInfoProvider>().As<IUserInfoProvider>();
            builder.RegisterType<ImagesHandler>().As<IFileHandler>();
            builder.RegisterType<FileManagementApplicationService>().As<IFileManagementApplicationService>();
            builder.RegisterType<SkillsApplicationService>().As<ISkillsApplicationService>();
            builder.RegisterType<SkillsManager>().As<ISkillsManager>();
            builder.RegisterType<ProfileApplicationService>().As<IProfileApplicationService>();
            builder.RegisterType<CommonInfoManager>().As<ICommonInfoManager>();
            builder.RegisterType<DashboardManager>().As<IDashboardManager>();
        }
    }
}
