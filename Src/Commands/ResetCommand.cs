using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoyConsPro.Src.Commands
{
    class ResetCommand : ICommand
    {
        private readonly Action _executeAction;

        public ResetCommand(Action executeAction)
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
