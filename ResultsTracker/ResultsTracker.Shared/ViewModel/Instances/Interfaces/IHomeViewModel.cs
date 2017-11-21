using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ResultsTracker
{
    public interface IHomeViewModel:IViewModel
    {
        string FullName { get; set; }

        string NavPage { get; set; }

        ICommand AttendCommand { get;}

         ObservableCollection<MeetingItem> Meetings { get; set; }
    }
}
