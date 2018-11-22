using System;
using System.Runtime.Serialization;

namespace HalloWCF.Host
{
    //[DataContract] braucht man nciht wenn man alle member veröffentlichen will
    public class Wurst
    {
        //[DataMember]
        public int Length { get; set; }
        public string MeatType { get; set; }

        public DateTime BestBefore { get; set; }
        public int EndCount { get; set; } = 2;
    }


}
