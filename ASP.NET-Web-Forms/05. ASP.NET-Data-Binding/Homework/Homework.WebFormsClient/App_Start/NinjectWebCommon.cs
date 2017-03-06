[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Homework.WebFormsClient.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Homework.WebFormsClient.App_Start.NinjectWebCommon), "Stop")]

namespace Homework.WebFormsClient.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Homework.Cars.Models.Factories;
    using Homework.Cars.Services.Contracts;
    using Homework.Cars.Services;
    using Ninject.Extensions.Factory;
    using Homework.Cars.Presenters;
    using Homework.Cars.Presenters.Contracts;
    using NinjectModules;
    using WebFormsMvp.Binder;
    using AutoMapper;
    using AutomapperProfiles;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel NinjectKernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                NinjectKernel = kernel;

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new MvpNinjectModule());
            kernel.Load(new CarsNinjectModule());
            kernel.Load(new EmployeesNinjectModule());

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new EmployeesProfile());
            });

            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();
        }
    }
}
