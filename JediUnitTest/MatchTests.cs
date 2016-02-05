using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using JediTournamentEntities;
using System.Linq;

namespace MatchTests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void AddMatchTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            Jedi jedi1 = new Jedi("Jean-Paul", true);
            Jedi jedi2 = new Jedi("Jean-Jacques", true);
            Stade stade = new Stade(12, "Naboo");
            Match newMatch = new Match(12,jedi1,jedi1,jedi2,EPhaseTournoi.DemiFinale, stade);
            jtm.AddMatch(newMatch);
            var matchs = jtm.GetMatchs();
            Assert.IsTrue(matchs.Last().Equals(newMatch));
        }

        [TestMethod()]
        public void DelMatchTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            var matchs = jtm.GetMatchs();
            jtm.DelMatch(matchs.Last());
            Assert.IsTrue(matchs.Count() - 1 == jtm.GetMatchs().Count());
        }
    }
}
