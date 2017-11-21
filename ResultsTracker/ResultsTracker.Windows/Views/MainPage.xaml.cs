using Windows.UI.Xaml.Controls;

namespace ResultsTracker
{
    [ViewModel(typeof(IHomeViewModel))]
    public sealed partial class MainPage : RTPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.InitializeViewModel();
            // DataContext = new HomeViewModel();
        }
        

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           // Frame.Navigate(typeof(CalendarPage));
        }
    }


}
