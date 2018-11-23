using ppedv.BigTuba.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BigTuba.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Teilnehmer> Teilnehmer { get; set; }
        public DbSet<Kurs> Kurse { get; set; }

        public EfContext(string conString) : base(conString)
        { }
        public EfContext()
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teilnehmer>().Property(x => x.Name)
                            .HasColumnName("DerNameDesTN")
                            .IsRequired()
                            .HasMaxLength(987);
        }
    }
}
