using Homework.Cars.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Cars.Services.Contracts
{
    public interface ICarsInformationService
    {
        IEnumerable<ICarModel> FindOrCreateCar(string producer, string model, ICollection<string> extras);

        IEnumerable<string> FindAvailableProducers();

        IEnumerable<string> FindAvailableModels(string producer = null);

        IEnumerable<string> FindAvailableExtras();
    }
}
