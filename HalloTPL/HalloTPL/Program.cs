using System;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //    Parallel.Invoke(Zähle, Zähle, Zähle, () => Console.WriteLine("Hallo"));
            //Parallel.For(0, 1000000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

            Task t1 = new Task(() =>
            {
                Console.WriteLine("T1 gestartet");
                Thread.Sleep(800);
                //throw new FieldAccessException();
                Console.WriteLine("T1 fertig");
            });

            t1.ContinueWith(t =>
            {
                Console.WriteLine("T1 continue");
            });


            t1.ContinueWith(t =>
            {
                Console.WriteLine($"T1 ERROR {t.Exception.InnerException.Message}");

            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);

            var tc1good= t1.ContinueWith(t =>
            {
                Console.WriteLine($"T1 alles Gut");

            }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);


            Task<long> t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 gestartet");
                Thread.Sleep(2600);
                Console.WriteLine("T2 fertig");
                return 234567890;
            });

            t1.Start();
            t2.Start();

            try
            {
                Task.WaitAll(t1, t2, tc1good);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }
    }
}
