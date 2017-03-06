using Homework.Cars.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Cars.ViewModels
{
    public class CreateCarFormViewModel
    {
        public IEnumerable<ICarModel> CreatedCar { get; set; }

        public IEnumerable<string> AvailableProducers { get; set; }

        public IEnumerable<string> AvailableModels { get; set; }

        public IEnumerable<string> AvailableExtras { get; set; }
    }
}
