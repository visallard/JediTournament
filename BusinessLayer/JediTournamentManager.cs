using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using JediTournamentEntities;

namespace BusinessLayer
{
    public class JediTournamentManager
    {
        public List<Stade> GetStades()
        {
            List<Stade> liste = new List<Stade>();
            liste.AddRange(DalManager.Instance.GetStades());
            return liste;
        }

        public List<Jedi> GetSiths()
        {
            List<Jedi> liste = new List<Jedi>();
            liste.AddRange(DalManager.Instance.GetJedis().Where(j => j.IsSith));
            return liste;
        }

        public List<Jedi> GetJedis()
        {
            return DalManager.Instance.GetJedis();
        }

        public List<Match> GetMatchs()
        {
            List<Match> liste = new List<Match>();
            liste.AddRange(DalManager.Instance.GetMatchs().Where(m => m.Stade.NbPlaces>200 && m.Jedi1.IsSith && m.Jedi2.IsSith));
            return liste;
        }
    }
}
