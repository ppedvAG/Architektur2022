using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ppedv.Garage.UI.WPF.ViewModels
{

    class CarsViewModel : ObservableObject
    {
        CarManager cm = new CarManager(new Data.EfCore.EfUnitOfWork());
        private Car selectedCar;

        public ObservableCollection<Car> Cars { get; set; }

        public SaveCommand SaveCommand { get; set; }
        public ICommand SaveCommand2 { get; set; }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                //selectedCar = value;
                SetProperty(ref selectedCar, value);
                OnPropertyChanged(nameof(Alter));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCar)));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
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

            SaveCommand2 = new RelayCommand(() => cm.UnitOfWork.SaveAll());
        }
    }
}
