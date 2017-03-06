using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Cars.Models.Contracts
{
    public interface ICarModel
    {
        string Producer { get; set; }

        string Model { get; set; }

        ICollection<string> Extras { get; set; }
    }
}
