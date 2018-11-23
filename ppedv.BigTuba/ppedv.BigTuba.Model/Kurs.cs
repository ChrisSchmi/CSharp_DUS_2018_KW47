using System;
using System.Collections.Generic;

namespace ppedv.BigTuba.Model
{
    public class Kurs : Entity
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public DateTime Datum { get; set; }
        public int Level { get; set; }
        public HashSet<Teilnehmer> Teilnehmer { get; set; } = new HashSet<Teilnehmer>();

    }
}
