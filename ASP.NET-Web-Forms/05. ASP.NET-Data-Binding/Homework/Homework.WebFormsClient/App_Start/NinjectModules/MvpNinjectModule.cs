using Homework.WebFormsClient.App_Start.Factories;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace Homework.WebFormsClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICreateCustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.GetPresenter).NamedLikeFactoryMethod((ICreateCustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToArray();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParameter);
        }
    }
}