using System.Windows;
using CsTest.WpfHost.ViewModel;
using CSTest.Shared.Model;

namespace CsTest.WpfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
