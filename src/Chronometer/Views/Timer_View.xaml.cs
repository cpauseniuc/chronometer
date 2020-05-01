using Chronometer.ViewModels;
using System.Windows.Controls;


namespace Chronometer.Views
{
    /// <summary>
    /// Interaction logic for Timer_View.xaml
    /// </summary>
    public partial class Timer_View : UserControl
    {
        public Timer_View()
        {

            InitializeComponent();
            DataContext = new Timer_ViewModel();

        }
    }
}
