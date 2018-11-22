using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloWCF.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetWurst(object sender, RoutedEventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            myGrid.ItemsSource = client.GetWurst();
        }

        private void GetBank(object sender, RoutedEventArgs e)
        {
            var client = new ServiceReference2.BLZServicePortTypeClient("BLZServiceSOAP12port_http");
            resultLbl.Content = client.getBank(tb.Text).bezeichnung;
        }
    }
}
