using System;
using System.Windows.Input;

namespace ResultsTracker
{
    public class NavigateCommand<T> : ICommand
        where T : IViewModel
    {
        private IViewModelHost Host { get;set; }

        public event EventHandler CanExecuteChanged;

        public NavigateCommand(IViewModelHost host)
        {
            this.Host = host;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public void Execute(object parameter)
        {
            this.Host.ShowView(typeof(T));
        }
    }
}
