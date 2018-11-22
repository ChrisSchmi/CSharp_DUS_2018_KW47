using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace HalloREST_Katzen
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

        private async void LoadJson(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string json = await wc.DownloadStringTaskAsync("https://cat-fact.herokuapp.com/facts");
                jsonTb.Text = json;

                CatFactResult result = JsonConvert.DeserializeObject<CatFactResult>(json);
                myGrid.ItemsSource = result.all.Where(x => x.text.Length > 5).OrderByDescending(x => x.upvotes.Length);
            }//wc.Dispose()
        }
    }
}
