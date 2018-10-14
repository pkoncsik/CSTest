using System.Windows;
using CSTest.Shared.Model;

namespace CsTest.WpfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var model = new GridModel();
           // DataContext = model;
           Tickers.ItemsSource = model.Trades;
        }
    }
}
