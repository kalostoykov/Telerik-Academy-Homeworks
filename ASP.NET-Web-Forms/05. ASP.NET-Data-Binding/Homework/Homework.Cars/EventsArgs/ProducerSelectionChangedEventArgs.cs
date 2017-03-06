using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Cars.EventsArgs
{
    public class ProducerSelectionChangedEventArgs : EventArgs
    {
        public ProducerSelectionChangedEventArgs(string selectedProducer)
        {
            this.SelectedProducer = selectedProducer;
        }

        public string SelectedProducer { get; set; }
    }
}
