using ppedv.Garage.Model.Contracts;
using System;
using System.Windows.Input;

namespace ppedv.Garage.UI.WPF.ViewModels
{
    class SaveCommand : ICommand
    {
        private readonly IUnitOfWork _uow;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public SaveCommand(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public void Execute(object? parameter)
        {
            _uow.SaveAll();
        }
    }
}
