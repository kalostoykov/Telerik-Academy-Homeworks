using Homework.Employees;
using Homework.Employees.Services;
using Homework.Employees.Services.Contracts;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using AutoMapper;
using Ninject.Activation;
using Homework.WebFormsClient.App_Start.AutomapperProfiles;
using Ninject;

namespace Homework.WebFormsClient.App_Start.NinjectModules
{
    public class EmployeesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<IEmployeesService>().SelectAllClasses().BindDefaultInterfaces());

            this.Bind<NorthwindEntities>().ToSelf().InSingletonScope();
            this.Bind<IConfigurationProvider>().ToMethod(this.GetConfiguration).InSingletonScope();
            this.Bind<IMapper>().ToMethod(x => x.Kernel.Get<IConfigurationProvider>().CreateMapper()).InSingletonScope();

            this.Rebind<IEmployeesService>().To<EmployeesService>().InSingletonScope();
        }

        private IConfigurationProvider GetConfiguration(IContext arg)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmployeesProfile());
            });

            return config;
        }
    }
}