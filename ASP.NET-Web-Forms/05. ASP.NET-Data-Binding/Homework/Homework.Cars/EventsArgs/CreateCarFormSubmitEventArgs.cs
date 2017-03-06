using System;
using System.Collections.Generic;

namespace Homework.Cars.EventsArgs
{
    public class CreateCarFormSubmitEventArgs : EventArgs
    {
        public CreateCarFormSubmitEventArgs(string selectedProducer, string selectedModel, ICollection<string> selectedExtras)
        {
            this.SelectedProducer = selectedProducer;
            this.SelectedModel = selectedModel;
            this.SelectedExtras = selectedExtras;
        }

        public string SelectedProducer { get; set; }

        public string SelectedModel { get; set; }

        public ICollection<string> SelectedExtras { get; set; }
    }
}
