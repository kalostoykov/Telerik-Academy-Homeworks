using Homework.NamePrinter.EventsArgs;
using Homework.NamePrinter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Homework.NamePrinter.Presenters
{
    public class NamePrinterPresenter : Presenter<INamePrinterView>
    {
        private INamePrinterView view;

        public NamePrinterPresenter(INamePrinterView view)
            : base(view)
        {
            this.view = view;

            this.view.PrintName += this.OnSubmit;
        }

        private void OnSubmit(object sender, NamePrinterEventArgs args)
        {
            string name = args.Name;
            this.view.Model.Message = "Hello " + name;
        }
    }
}
