using Homework.Cars.Presenters.Contracts;
using Homework.Cars.ViewModels;
using Homework.Cars.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using Homework.Cars.EventsArgs;

namespace Homework.WebFormsClient.UserControls
{
    [PresenterBinding(typeof(ICreateCarFormPresenter))]
    public partial class CarsUserControl : MvpUserControl<CreateCarFormViewModel>, ICreateCarFormView
    {
        public event EventHandler<ProducerSelectionChangedEventArgs> ProducerSelectionChanged;
        public event EventHandler<CreateCarFormSubmitEventArgs> CreateCarFormSubmit;
        public event EventHandler InitialState;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.InitialState?.Invoke(null, null);

                this.DropDownListProducers.DataSource = this.Model.AvailableProducers;
                this.DropDownListProducers.DataBind();

                this.DropDownListModels.DataSource = this.Model.AvailableModels;
                this.DropDownListModels.DataBind();

                this.CheckBoxListExtras.DataSource = this.Model.AvailableExtras;
                this.CheckBoxListExtras.DataBind();
            }
        }

        protected void DropDownListProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducer = this.DropDownListProducers.SelectedItem.Text;
            var producerSelectionChangedEventArgs = new ProducerSelectionChangedEventArgs(selectedProducer);
            this.ProducerSelectionChanged?.Invoke(null, producerSelectionChangedEventArgs);

            this.DropDownListModels.DataSource = this.Model.AvailableModels;
            this.DropDownListModels.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var selectedProducer = this.DropDownListProducers.SelectedItem.Text;
            var selectedModel = this.DropDownListModels.SelectedItem.Text;

            var selectedExtras = new LinkedList<string>();
            foreach (ListItem item in this.CheckBoxListExtras.Items)
            {
                if (item.Selected)
                {
                    selectedExtras.AddLast(item.Text);
                }
            }

            var createCarFormSubmitEventArgs = new CreateCarFormSubmitEventArgs(selectedProducer, selectedModel, selectedExtras);
            this.CreateCarFormSubmit?.Invoke(null, createCarFormSubmitEventArgs);

            this.DetailsViewCreatedCar.DataSource = this.Model.CreatedCar;
            this.DetailsViewCreatedCar.DataBind();

            this.GridViewCreatedCar.DataSource = this.Model.CreatedCar.First().Extras;
            this.GridViewCreatedCar.DataBind();

        }
    }
}