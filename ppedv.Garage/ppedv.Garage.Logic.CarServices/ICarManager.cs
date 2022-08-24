using ppedv.Garage.Model;

namespace ppedv.Garage.Logic.CarServices
{
    public interface ICarManager
    {
        bool CheckColor(Car car, IEnumerable<string> allowedColor);
        Location? GetLocationWithFastesCars();
    }
}