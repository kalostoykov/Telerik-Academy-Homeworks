using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace Homework.WebFormsClient.App_Start.Factories
{
    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICreateCustomPresenterFactory factory;

        public WebFormsMvpPresenterFactory(ICreateCustomPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}