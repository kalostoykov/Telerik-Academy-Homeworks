using Homework.NamePrinter.EventsArgs;
using Homework.NamePrinter.Models;
using System;
using WebFormsMvp;

namespace Homework.NamePrinter.Views
{
    public interface INamePrinterView : IView<NamePrinterViewModel>
    {
        event EventHandler<NamePrinterEventArgs> PrintName;
    }
}
