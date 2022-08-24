using ppedv.Garage.Model;

namespace ppedv.Garage.Model.Contracts.Services
{
    public interface ICarManager
    {
        bool CheckColor(Car car, IEnumerable<string> allowedColor);
        Location? GetLocationWithFastesCars();
    }
}