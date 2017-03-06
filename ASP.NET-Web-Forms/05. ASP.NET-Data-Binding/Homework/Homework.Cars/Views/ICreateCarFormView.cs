using Homework.Cars.EventsArgs;
using Homework.Cars.ViewModels;
using System;
using WebFormsMvp;

namespace Homework.Cars.Views
{
    public interface ICreateCarFormView : IView<CreateCarFormViewModel>
    {
        event EventHandler<ProducerSelectionChangedEventArgs> ProducerSelectionChanged;

        event EventHandler<CreateCarFormSubmitEventArgs> CreateCarFormSubmit;

        event EventHandler InitialState;
    }
}
