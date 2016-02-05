using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using JediTournamentEntities;
using System.Linq;

namespace TournoiTests
{
    [TestClass]
    public class TournoiTests
    {
        [TestMethod]
        public void AddTournoiTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            Tournoi tournoi = new Tournoi(12, "Course de la Boonta");
            jtm.AddTournoi(tournoi);
            var tournois = jtm.GetTournois();
            Assert.IsTrue(tournois.Last().Equals(tournoi));
        }

        [TestMethod()]
        public void DelTournoiTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            var tournois = jtm.GetTournois();
            jtm.DelTournoi(tournois.Last());
            Assert.IsTrue(tournois.Count() - 1 == jtm.GetTournois().Count());
        }
    }
}
