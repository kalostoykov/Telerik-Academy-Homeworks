using Homework.Cars.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using Homework.Cars.Models.Contracts;
using Homework.Cars.Models.Factories;
using System.Collections.ObjectModel;

namespace Homework.Cars.Services
{
    public class CarsInformationService : ICarsInformationService
    {
        private readonly ICreateCarFormModelsFactory carsFactory;
        private readonly ICollection<ICarModel> existingCars;

        private IEnumerable<string> availableProducers;
        private IDictionary<string, ICollection<string>> modelsByProducers;
        private IEnumerable<string> availableExtras;

        public CarsInformationService(ICreateCarFormModelsFactory carsFactory)
        {
            this.carsFactory = carsFactory;

            this.availableProducers = this.CreateAvailableProducers();
            this.modelsByProducers = this.CreateModelsByProducer();
            this.availableExtras = this.CreateAvailableExtras();

            this.existingCars = new HashSet<ICarModel>();
        }

        private IEnumerable<string> CreateAvailableExtras()
        {
            var extras = new[] {
                "Extra 1",
                "Extra 2",
                "Extra 3"
            };

            return extras;
        }

        private IDictionary<string, ICollection<string>> CreateModelsByProducer()
        {
            var modelsByProducers = new Dictionary<string, ICollection<string>>();

            modelsByProducers.Add("Producer 1", new HashSet<string>() { "Model 1", "Model 2", "Model 3" });
            modelsByProducers.Add("Producer 2", new HashSet<string>() { "Model 1", "Model 2", "Model 3", "Model 4" });
            modelsByProducers.Add("Producer 3", new HashSet<string>() { "Model 1", "Model 2", "Model 3", "Model 4", "Model 5" });

            return modelsByProducers;
        }

        private IEnumerable<string> CreateAvailableProducers()
        {
            var producers = new[]
            {
                "Producer 1",
                "Producer 2",
                "Producer 3"
            };

            return producers;
        }

        public IEnumerable<string> FindAvailableModels(string producer = null)
        {
            if (producer == null)
            {
                producer = this.availableProducers.First();
            }

            return this.modelsByProducers[producer];
        }

        public IEnumerable<string> FindAvailableExtras()
        {
            return this.availableExtras;
        }

        public IEnumerable<string> FindAvailableProducers()
        {
            return this.availableProducers;
        }

        public IEnumerable<ICarModel> FindOrCreateCar(string producer, string model, ICollection<string> extras)
        {
            var car = this.carsFactory.CreateCarModel(producer, model, extras);
            this.existingCars.Add(car);

            return new Collection<ICarModel>() { car };
        }
    }
}
