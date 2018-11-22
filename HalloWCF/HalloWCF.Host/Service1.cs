using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HalloWCF.Host
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<Wurst> GetWurst()
        {
            yield return new Wurst() { Length = 7, BestBefore = DateTime.Now.AddDays(5), MeatType = "Tier" };
            yield return new Wurst() { Length = 3, BestBefore = DateTime.Now.AddDays(12), MeatType = "Rind" };
            yield return new Wurst() { Length = 12, BestBefore = DateTime.Now.AddDays(2000), MeatType = "Schwein" };
        }
    }
}
