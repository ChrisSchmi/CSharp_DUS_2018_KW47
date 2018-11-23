using System;
using System.Collections.Generic;

namespace ppedv.BigTuba.Model
{
    public class Teilnehmer : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public string Firma { get; set; }
        public HashSet<Kurs> Kurse { get; set; } = new HashSet<Kurs>();
    }
}
