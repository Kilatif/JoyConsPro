using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoyConsPro.Src.Commands
{
    class FindCommand : ICommand
    {
        private readonly Action _executeAction;

        public FindCommand(Action executeAction)
        {
            _executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}
