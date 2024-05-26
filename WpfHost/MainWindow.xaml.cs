using ServiceModel;
using System.ServiceModel;
using System.Windows;
namespace WpfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceHost service = new ServiceHost(typeof(CalendarService));
            service.Open();
        }
    }
}
