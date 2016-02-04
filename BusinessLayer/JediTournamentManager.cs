using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using JediTournamentEntities;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class JediTournamentManager
    {
        public IEnumerable<Stade> GetStades()
        {
            return DalManager.Instance.GetStades();
        }

        public IEnumerable<Jedi> GetSiths()
        {
            return DalManager.Instance.GetJedis().Where(j => j.IsSith);
        }

        public IEnumerable<Jedi> GetJedis()
        {
            return DalManager.Instance.GetJedis().Where(j => !j.IsSith);
        }

        public IEnumerable<Match> GetMatchs()
        {
            return DalManager.Instance.GetMatchs();
        }

        public void AddJedi(Jedi jedi)
        {
            DalManager.Instance.AddJedi(jedi);
        }

        public IEnumerable<Tournoi> GetTournois()
        {
            return DalManager.Instance.GetTournois();
        }
        public void AddStade(Stade stade)
        {
            DalManager.Instance.AddStade(stade);
        }
    }
}
