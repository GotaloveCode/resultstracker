using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ResultsTracker
{
    public class HomeViewModel:ViewModel,IHomeViewModel
    {
        public string FullName { get; set; }

        public string NavPage { get; set; }

        public ICommand AttendCommand { get; private set; }

        public ObservableCollection<MeetingItem> Meetings { get; set; }

        public HomeViewModel()
        {
            FullName = "Martin Iriga";
            NavPage = "Dashboard";
            Meetings = new ObservableCollection<MeetingItem>()
            {
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="James",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Mat",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Ben",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Collo",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="John",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Steve",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Brian",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Hash",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Jill",Venue="board room" },
                new MeetingItem() {Meeting ="Managing Comm", Agenda ="Progress",Attending="Stan",Venue="board room" },
            };
        }

    }
}
