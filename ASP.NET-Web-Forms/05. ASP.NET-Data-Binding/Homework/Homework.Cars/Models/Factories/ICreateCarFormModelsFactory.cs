using Homework.Cars.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Cars.Models.Factories
{
    public interface ICreateCarFormModelsFactory
    {
        ICarModel CreateCarModel(string producer, string model, ICollection<string> extras);
    }
}
