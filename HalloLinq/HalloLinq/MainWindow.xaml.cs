using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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




            new HalloDelegate().MeinEvent += MainWindow_MeinEvent;
        }

        private void MainWindow_MeinEvent(string arg1, DateTime arg2, long arg3)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("lala");

        }

        private void AlleAnzeigen(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = persons;
        }

        private void AlleAb35(object sender, RoutedEventArgs e)
        {
            var query = from p in persons
                        where p.Birthdate < DateTime.Now.AddYears(-35) && p.Name.StartsWith("F")
                        orderby p.Age, p.Birthdate.Month descending
                        select p;
            //select new { DerName = p.Name, Monat = p.Birthdate.Month };

            myGrid.ItemsSource = query.ToList();
        }

        private void AlleAb35LAMB(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = persons.Where(x => x.Birthdate < DateTime.Now.AddYears(-35) && x.Name.StartsWith("F"))
                                        .OrderBy(x => x.Age)
                                        .ThenBy(x => x.Birthdate.Month).ToList();
            //.Select(x=>new { lala=x.Name,})
        }

        private void ErstenAbMai(object sender, RoutedEventArgs e)
        {
            //Person p = persons.OrderBy(x => x.Age).FirstOrDefault(x => x.Birthdate.Month == 5);
            //if (p != default(Person))
            //    MessageBox.Show(p.Name);

            MessageBox.Show(persons.Count(x => x.Age > 35).ToString());
        }

        string filename = "Äxcel👔.xlsx";
        private void Export(object sender, RoutedEventArgs e)
        {
            var fi = new FileInfo(filename);
            var pack = new ExcelPackage(fi);
            var ws = pack.Workbook.Worksheets.FirstOrDefault();
            if (ws == null)
                ws = pack.Workbook.Worksheets.Add("Test");


            //for (int i = 0; i < persons.Count; i++)
            //{
            //    ws.Cells[i + 1, 1].Value = persons[i].Name;
            //    ws.Cells[i + 1, 2].Value = persons[i].Age;

            //    ws.Cells[i + 1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.LightHorizontal;
            //    ws.Cells[i + 1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);
            //}
            int row = 1;
            int col = 1;
            foreach (var monat in persons.GroupBy(x => x.Birthdate.Month).OrderBy(x => x.Key))
            {
                row = 1;
                ws.Cells[row, col].Value = $"{new DateTime(2000, monat.Key, 1).ToString("MMMM")} [{monat.Count()}]";
                row++;
                foreach (var p in monat.OrderByDescending(x => x.Name))
                {
                    ws.Cells[row, col].Value = p.Name;
                    if (row % 3 == 0 && col % 2 == 0)
                    {
                        ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[row, col].Style.Fill.BackgroundColor.Indexed = 4;
                    }
                    row++;
                }
                col++;
            }

            pack.Save();

            Process.Start(filename);
        }

        private void QueryExcel(object sender, RoutedEventArgs e)
        {
            var fi = new FileInfo(filename);
            var pack = new ExcelPackage(fi);
            var ws = pack.Workbook.Worksheets.First();


            var result = ws.Cells["A1:L100"].Where(x => x.Style.Fill.BackgroundColor.Indexed == 4).Select(x => x.Value.ToString());

            MessageBox.Show(string.Join(Environment.NewLine, result));
        }
    }
}
