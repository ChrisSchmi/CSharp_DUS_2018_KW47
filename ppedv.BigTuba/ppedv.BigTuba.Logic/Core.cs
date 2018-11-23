using ppedv.BigTuba.Model;
using ppedv.BigTuba.Model.Contracts;
using System;
using System.Linq;
using System.Threading;

namespace ppedv.BigTuba.Logic
{
    public class Core
    {

        public IRepository Repository { get; private set; }

        public Core(IRepository repos)
        {
            Repository = repos;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

        public void CreateDemoDaten()
        {
            var k1 = new Kurs() { Name = "C# für Anfänger", Datum = DateTime.Now };
            var k2 = new Kurs() { Name = "C# für Fortgeschrittene", Datum = DateTime.Now.AddDays(4) };

            for (int i = 0; i < 100; i++)
            {
                var t = new Teilnehmer() { Name = $"Fred #{i:000}", GebDatum = DateTime.Now.AddYears(-40).AddDays(i * 17) };
                if (i % 2 == 0)
                    k1.Teilnehmer.Add(t);
                if (i % 3 == 0)
                    k2.Teilnehmer.Add(t);
            }
            Repository.Add(k1);
            Repository.Add(k2);
            Repository.SaveAll();
        }

        public void CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound()
        {
            //Prüfung ob ein TN in einem Kurs am Kurstag GebTag hat
            if (Repository.GetAll<Kurs>().Any(x => x.Teilnehmer.Any(y => y.GebDatum.DayOfYear == x.Datum.DayOfYear)))
            {
                PlayHappyBDay();
            }
        }

        public virtual void PlayHappyBDay()
        {
            #region play Happy Birthday
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            #endregion
        }
    }
}
