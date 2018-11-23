using ppedv.BigTuba.Logic;
using ppedv.BigTuba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BigTuba.UI.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** BIG TUBA ***");

            var core = new Core();

            core.CreateDemoDaten();

            foreach (var k in core.Repository.GetAll<Kurs>())
            {
                Console.WriteLine($"{k.Name} {k.Datum:d}");
                foreach (var t in k.Teilnehmer)
                {
                    Console.WriteLine($"{t.Name}");
                }
            }

            core.CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound();


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
