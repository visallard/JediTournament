using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using JediTournamentEntities;
using System.Linq;

namespace StadeTests
{
    [TestClass]
    public class StadeTests
    {
        [TestMethod]
        public void AddStadeTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            Stade stade = new Stade(12, "Naboo");
            jtm.AddStade(stade);
            var stades = jtm.GetStades();
            Assert.IsTrue(stades.Last().Equals(stade));
        }

        [TestMethod()]
        public void DelStadeTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            var stades = jtm.GetStades();
            jtm.DelStade(stades.Last());
            Assert.IsTrue(stades.Count() - 1 == jtm.GetStades().Count());
        }
    }
}
