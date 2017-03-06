using Homework.Cars.Presenters.Contracts;
using Homework.Cars.Services.Contracts;
using Homework.Cars.Views;
using System;
using WebFormsMvp;
using Homework.Cars.EventsArgs;

namespace Homework.Cars.Presenters
{
    public class CreateCarFormPresenter : Presenter<ICreateCarFormView>, ICreateCarFormPresenter
    {
        private readonly ICreateCarFormView view;
        private readonly ICarsInformationService carsInformationService;

        public CreateCarFormPresenter(ICreateCarFormView view, ICarsInformationService carsInformationService)
            : base(view)
        {
            this.view = view;

            this.view.ProducerSelectionChanged += this.OnProducerSelectionChanged;
            this.view.CreateCarFormSubmit += this.OnCreateCarFormSubmit;
            this.view.InitialState += this.OnInitialState;

            this.carsInformationService = carsInformationService;
        }

        private void OnInitialState(object sender, EventArgs e)
        {
            this.view.Model.AvailableProducers = this.carsInformationService.FindAvailableProducers();
            this.view.Model.AvailableModels = this.carsInformationService.FindAvailableModels();
            this.view.Model.AvailableExtras = this.carsInformationService.FindAvailableExtras();
        }

        private void OnCreateCarFormSubmit(object sender, CreateCarFormSubmitEventArgs args)
        {
            this.view.Model.CreatedCar = this.carsInformationService.FindOrCreateCar(args.SelectedProducer, args.SelectedModel, args.SelectedExtras);
        }

        private void OnProducerSelectionChanged(object sender, ProducerSelectionChangedEventArgs args)
        {
            this.view.Model.AvailableModels = this.carsInformationService.FindAvailableModels(args.SelectedProducer);
        }
    }
}
