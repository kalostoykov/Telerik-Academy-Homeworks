using Homework.Cars.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Cars.Models
{
    public class CarModel : ICarModel
    {
        public CarModel(string producer, string model, ICollection<string> extras)
        {
            this.Producer = producer;
            this.Model = model;
            this.Extras = extras;
        }

        public ICollection<string> Extras { get; set; }

        public string Model { get; set; }

        public string Producer { get; set; }

        public override int GetHashCode()
        {
            var hash = 199;

            unchecked
            {
                hash = hash * 127 + this.Producer.GetHashCode();
                hash = hash * 127 + this.Model.GetHashCode();

                foreach (var option in this.Extras)
                {
                    hash = hash * 127 + option.GetHashCode();
                }
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var otherCar = obj as CarModel;
            if (otherCar == null)
            {
                return false;
            }

            var producerIsEqual = this.Producer == otherCar.Producer;
            var modelIsEqual = this.Model == otherCar.Model;

            var optionsAreEqual = this.Extras.Count == otherCar.Extras.Count;
            if (optionsAreEqual)
            {
                var thisOptionsEnumerator = this.Extras.GetEnumerator();
                var otherOptionsEnumerator = otherCar.Extras.GetEnumerator();

                while (thisOptionsEnumerator.MoveNext() && otherOptionsEnumerator.MoveNext())
                {
                    var thisValue = thisOptionsEnumerator.Current;
                    var otherValue = otherOptionsEnumerator.Current;

                    var optionIsEqual = thisValue == otherValue;
                    if (!optionIsEqual)
                    {
                        optionsAreEqual = false;
                        break;
                    }
                }
            }

            return producerIsEqual && modelIsEqual && optionsAreEqual;
        }
    }
}
