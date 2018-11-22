using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloREST_Katzen
{

    public class CatFactResult
    {
        public All[] all { get; set; }
        public object[] me { get; set; }
    }

    public class All
    {
        public string _id { get; set; }
        public string text { get; set; }
        public User user { get; set; }
        public Upvote[] upvotes { get; set; }
    }

    public class User
    {
        public string _id { get; set; }
        public Name name { get; set; }
    }

    public class Name
    {
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Upvote
    {
        public string user { get; set; }
    }

}
