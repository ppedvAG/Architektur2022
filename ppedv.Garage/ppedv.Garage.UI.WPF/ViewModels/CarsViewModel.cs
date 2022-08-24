using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ppedv.Garage.UI.WPF.ViewModels
{

    class CarsViewModel : INotifyPropertyChanged
    {
        CarManager cm = new CarManager(new Data.EfCore.EfUnitOfWork());
        private Car selectedCar;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Car> Cars { get; set; }

        public SaveCommand SaveCommand { get; set; }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCar)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public string Alter
        {
            get
            {
                if (SelectedCar == null) return "-";
                return (DateTime.Now.Year - SelectedCar.BuiltDate.Year).ToString();
            }
        }


        public CarsViewModel()
        {
            Cars = new ObservableCollection<Car>(cm.UnitOfWork.CarRepository.Query());
            SaveCommand = new SaveCommand(cm.UnitOfWork);
        }
    }
}
