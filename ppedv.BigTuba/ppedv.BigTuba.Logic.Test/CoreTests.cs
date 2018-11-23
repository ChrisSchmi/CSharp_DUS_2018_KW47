using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.BigTuba.Model;
using ppedv.BigTuba.Model.Contracts;

namespace ppedv.BigTuba.Logic.Test
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound_No_Kurse()
        {
            var repoMock = new Mock<IRepository>();
            var core = new Core(repoMock.Object);

            core.CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound();

        }

        [TestMethod]
        public void Core_CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound_1_Kurs_Mit_1_Teilnehmer_Der_GebTag_hat()
        {
            var repoMock = new Mock<IRepository>();
            repoMock.Setup(x => x.GetAll<Kurs>()).Returns(() =>
            {
                var k1 = new Kurs() { Datum = new DateTime(2000, 1, 1) };
                k1.Teilnehmer.Add(new Teilnehmer() { GebDatum = new DateTime(2000, 1, 1) });
                return new[] { k1 };
            });
            var core = new Core(repoMock.Object);

            core.CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound();

        }

        [TestMethod]
        public void Core_CheckIfTeilnehmerHasBirthdayThenPlayHappyBirthdaySound_1_Kurs_Mit_1_Teilnehmer_Der_NICHT_GebTag_hat()
        {

        }
    }
}
