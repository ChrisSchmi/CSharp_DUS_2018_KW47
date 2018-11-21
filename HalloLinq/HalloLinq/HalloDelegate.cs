using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloLinq
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string msg);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
       public event Action<string, DateTime, long> MeinEvent;

        public HalloDelegate()
        {

            MeinEvent("Hallo", DateTime.Now, 857575);

            EinfacherDelegate meinDele = EinfacheMethode;
            Action meinDeleAlsActio = EinfacheMethode;
            EinfacherDelegate actionAno = delegate () { Console.WriteLine("hallo"); };
            EinfacherDelegate actionAno2 = () => { Console.WriteLine("hallo"); };
            EinfacherDelegate actionAno3 = () => Console.WriteLine("hallo");

            DelegateMitPara meinDeleMitPara = MethodeMitPara;
            Action<string> meinDeleAlsAction = MethodeMitPara;
            Action<string> meinDeleAlsAction2 = (string peter) => { Console.WriteLine(peter); };
            Action<string> meinDeleAlsAction3 = (peter) => Console.WriteLine(peter);
            Action<string> meinDeleAlsAction4 = x => Console.WriteLine(x);

            CalcDelegate meinCalc = Minus;
            Func<int, int, long> meinCalc2 = Sum;
            CalcDelegate meinCalcAno = (x, y) => { return x + y; };
            CalcDelegate meinCalcAno2 = (x, y) => x + y;

            List<string> daten = new List<string>();
            var result = daten.Where(Filter);
            var resutl2 = daten.Where(x => x.StartsWith("F"));
        }



        private bool Filter(string arg)
        {
            if (arg.StartsWith("F"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string txt)
        {
            Console.WriteLine(txt);

        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
