using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using System.Collections.ObjectModel;

namespace ppedv.Garage.UI.WPF.ViewModels
{
    class CarsViewModel
    {
        CarManager cm = new CarManager(new Data.EfCore.EfUnitOfWork());

        public ObservableCollection<Car> Cars { get; set; }

        public CarsViewModel()
        {
            Cars = new ObservableCollection<Car>(cm.UnitOfWork.CarRepository.Query());
        }
    }
}
