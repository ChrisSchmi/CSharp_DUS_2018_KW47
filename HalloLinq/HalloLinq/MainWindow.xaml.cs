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

namespace HalloLinq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> persons = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();


            for (int i = 0; i < 100; i++)
            {
                persons.Add(new Person()
                {
                    Id = i,
                    Name = $"Fred #{i:000}",
                    Birthdate = DateTime.Now.AddYears(-40).AddDays(i * 57)
                });
            }

            var txt = "Wilma";
            int zahl = 5;

            string ausgabe = "Hallo " + txt + " Heute sind " + zahl + "°C";
            string ausgabeF = string.Format("Hallo {0} Heute sind {1:00} °C", txt, zahl);
            string ausgabeI = $"Hallo {txt} Heute sind {zahl:000} °C";
        }


        private void AlleAnzeigen(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = persons;
        }

        private void AlleAb35(object sender, RoutedEventArgs e)
        {
            var query = from p in persons
                        where p.Birthdate < DateTime.Now.AddYears(-35)
                        select p;

            myGrid.ItemsSource = query.ToList();
        }
    }
}
