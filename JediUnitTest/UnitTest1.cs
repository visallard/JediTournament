using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using JediTournamentEntities;

namespace DataAccessLayer.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void AddJediTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            Jedi newJedi = new Jedi("Palpatine", true);
            jtm.AddJedi(newJedi);
            var jedis = jtm.GetJedis();
            Assert.IsTrue(jedis.Last().Equals(newJedi));
        }

        [TestMethod()]
        public void DelJediTest()
        {
            JediTournamentManager jtm = new JediTournamentManager();
            var jedis = jtm.GetJedis();
            jtm.DelJedi(jedis.Last());
            Assert.IsTrue(jedis.Count()-1 == jtm.GetJedis().Count());
        }
    }
}
