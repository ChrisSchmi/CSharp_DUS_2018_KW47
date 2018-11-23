using Autofac;
using ppedv.BigTuba.Data.EF;
using ppedv.BigTuba.Logic;
using ppedv.BigTuba.Model;
using ppedv.BigTuba.Model.Contracts;
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
            var builder = new ContainerBuilder();

            // Once a listener has been fully constructed and is
            // ready to be used, automatically start listening.
            builder.RegisterType(typeof(EfRepository))
                   .As<IRepository>();
            var conainer =  builder.Build();

            var core = new Core(conainer.Resolve<IRepository>());

            //core.CreateDemoDaten();

            foreach (var k in core.Repository.GetAll<Kurs>())
            {
                Console.WriteLine($"{k.Name} {k.Datum:d}");
                foreach (var t in k.Teilnehmer)
                {
                    Console.WriteLine($"{t.Name} {t.GebDatum:d}");

                    if (t.GebDatum.DayOfYear == k.Datum.DayOfYear)
                        Console.WriteLine("🎂🎂");
                }
            }

            core.CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound();


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
