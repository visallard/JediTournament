using System;
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
            JediTournamentEntities.Jedi insert = new JediTournamentEntities.Jedi("JarJar", true);
            test.AddJedi(insert);
            List<JediTournamentEntities.Jedi> jedis = new List<JediTournamentEntities.Jedi>(test.GetJedis());

            Assert.IsTrue(jedis.Contains(insert));
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
