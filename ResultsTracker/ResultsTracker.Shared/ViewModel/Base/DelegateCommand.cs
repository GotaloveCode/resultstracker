using System;
using System.Windows.Input;

namespace ResultsTracker
{
    public class DelegateCommand : ICommand
    {
        private Action<object> Handler {get;set; }

        public event EventHandler CanExecuteChanged = null;

        public DelegateCommand(Action<object> handler)
        {
            // store a reference to the delegate to invoke...
            this.Handler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {
            // invoke the delegate that we stored earlier...
            Handler(parameter);
        }
    }
}
