using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CircuitSimulator.Handlers
{
    public class RelayCommand : ICommand
    {
        private Action _actionToExecute;
        public RelayCommand(Action a)
        {
            _actionToExecute = a;
        }


        public void Execute(object parameter)
        {
            _actionToExecute();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

    }
}
