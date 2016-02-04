using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessLayer.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void AddJediTest()
        {
            BusinessLayer.JediTournamentManager test = new BusinessLayer.JediTournamentManager();
            JediTournamentEntities.Jedi insert = new JediTournamentEntities.Jedi("Palpatine", true);
            test.AddJedi(insert);
            List<JediTournamentEntities.Jedi> jedis = test.GetJedis().ToList<JediTournamentEntities.Jedi>();

            Assert.IsTrue(jedis.Exists(x => x.Nom== "Palpatine"));
        }
    }
}

namespace JediUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
