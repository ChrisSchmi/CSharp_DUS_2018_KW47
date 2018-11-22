using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HalloAsync
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

        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;
                Thread.Sleep(300);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    Thread.Sleep(30);
                }
                pb1.Dispatcher.Invoke(() => ((Button)sender).IsEnabled = true);

            });
        }

        private void StartTaskmitTS(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            cts = new CancellationTokenSource();

            var ts = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Task.Factory.StartNew(() => pb1.Value = i, cts.Token, TaskCreationOptions.None, ts);
                    Thread.Sleep(300);
                    if (cts.IsCancellationRequested)
                        break;
                }
            }).ContinueWith(t => { ((Button)sender).IsEnabled = true; }, CancellationToken.None, TaskContinuationOptions.None, ts);


        }

        CancellationTokenSource cts = null;
        private void Abort(object sender, RoutedEventArgs e)
        {
            if (cts != null)
                cts.Cancel();
        }

        private async void LadeHttp(object sender, RoutedEventArgs e)
        {
            var webClient = new WebClient();
            tb1.Text = await webClient.DownloadStringTaskAsync("https://cat-fact.herokuapp.com/facts");
        }

        private async void AlteMethode(object sender, RoutedEventArgs e)
        {
            long zahl = await AlteLangsameMethodeAsync();

            MessageBox.Show(zahl.ToString());
        }

        private Task<long> AlteLangsameMethodeAsync()
        {
            return Task.Run(() => AlteLangsameMethode());
        }

        private long AlteLangsameMethode()
        {
            Thread.Sleep(3000);
            return 234567890;
        }
    }
}
