using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ppedv.Garage.UI.WPF.ViewModels
{

    class CarsViewModel : ObservableObject
    {
        

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

        IUnitOfWork uow;
        public CarsViewModel()
        {
            uow = App.Current.Services.GetService<IUnitOfWork>();

            Cars = new ObservableCollection<Car>(uow.CarRepository.Query());
            SaveCommand = new SaveCommand(uow);

            SaveCommand2 = new RelayCommand(() => uow.SaveAll());

        }
    }
}
