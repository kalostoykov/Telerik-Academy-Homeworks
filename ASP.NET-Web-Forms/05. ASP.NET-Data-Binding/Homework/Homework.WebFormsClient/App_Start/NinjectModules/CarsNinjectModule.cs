using Homework.Cars.Models.Factories;
using Homework.Cars.Services;
using Homework.Cars.Services.Contracts;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Homework.WebFormsClient.App_Start.NinjectModules
{
    public class CarsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<ICreateCarFormModelsFactory>().SelectAllClasses().BindDefaultInterfaces());

            this.Rebind<ICarsInformationService>().To<CarsInformationService>();
            this.Bind<ICreateCarFormModelsFactory>().ToFactory().InSingletonScope();
        }
    }
}