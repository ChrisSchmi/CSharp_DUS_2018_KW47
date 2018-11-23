using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.BigTuba.Model;

namespace ppedv.BigTuba.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_Database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                Assert.IsFalse(con.Database.Exists());

                con.Database.Create();

                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_can_insert_read_Kurs()
        {
            Kurs kurs = new Kurs() { Name = "Testkurs", Datum = DateTime.Now };

            using (var con = new EfContext())
            {
                con.Kurse.Add(kurs);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Kurse.Find(kurs.Id);
                Assert.AreEqual(kurs.Name, loaded.Name);
            }
        }

        [TestMethod]
        public void DateTime_AddDays_1_Results_Saturday()
        {
            //Arrange
            var dt = new DateTime(2018, 11, 23);

            //Act
            var result = dt.AddDays(1);

            //Assert
            Assert.AreEqual(DayOfWeek.Saturday, result.DayOfWeek);
        }
    }
}
