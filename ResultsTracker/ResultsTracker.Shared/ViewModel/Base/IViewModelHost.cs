using System;
using System.Threading.Tasks;


namespace ResultsTracker
{
    // provides a route back from a view-model to a view...
    public interface IViewModelHost
    {
        Task ShowAlertAsync(ErrorBucket errors);
        Task ShowAlertAsync(string message);
#if WINDOWS_PHONE_APP
        Task ToggleProgressBar(bool toggle, string message="");
#endif

        // shows a view from a given view-model...
        void ShowView(Type viewModelInterfaceType, object parameter = null);
    }
}
