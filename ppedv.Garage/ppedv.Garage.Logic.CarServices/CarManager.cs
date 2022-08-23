using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts;

namespace ppedv.Garage.Logic.CarServices
{
    public class CarManager
    {

        public IRepository Repository { get; }

        public CarManager(IRepository repository)
        {
            Repository = repository;
        }

        public Location GetLocationWithFastesCars()
        {
            return Repository.GetAll<Location>().OrderBy(x => x.Cars.Sum(c => c.KW)).FirstOrDefault();
        }

        public bool CheckColor(Car car, IEnumerable<string> allowedColor)
        {
            if (car == null)
                throw new ArgumentNullException("car");

            if (car == allowedColor)
                throw new ArgumentNullException("allowedColor");

            if (string.IsNullOrWhiteSpace(car.Color))
                throw new ArgumentException("color ist null or empty");

            return allowedColor.Contains(car.Color);
        }
    }
}