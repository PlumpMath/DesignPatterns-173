using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CircuitSimulator.Handlers
{
    class RelayCommand : ICommand
    {
        private Action _actionToExecute;
        public RelayCommand(Action a)
        {
            _actionToExecute = a;
        }

        public Boolean canExecute
        {
            get
            {
                return true;
            }
        }

        public void Execute()
        {
            _actionToExecute();
        }
    }
}
