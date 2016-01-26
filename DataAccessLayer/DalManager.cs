using JediTournamentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManager
    {
        private static DalManager _instance;
        private static readonly Object padlock = new Object();

        private DataAccess _DataAccess;

        private DalManager()
        {
            _DataAccess = new AzureDataAccess();
        }

        List<Jedi> GetJedis()
        {
            return _DataAccess.GetJedis();
        }

        List<Match> GetMatchs()
        {
            return _DataAccess.GetMatchs();
        }

        List<Stade> GetStades()
        {
            return _DataAccess.GetStades();
        }


        void addJedi(Jedi jedi)
        {
            _DataAccess.addJedi(jedi);
        }

        void addMatch(Match match)
        {
            _DataAccess.addMatch(match);
        }

        void addStade(Stade stade)
        {
            _DataAccess.addStade(stade);
        }

        void updateJedi(Jedi jedi)
        {
            _DataAccess.updateJedi(jedi);
        }

        void updateMatch(Match match)
        {
            _DataAccess.updateMatch(match);
        }

        void updateStade(Stade stade)
        {
            _DataAccess.updateStade(stade);
        }

        void deleteJedi(Jedi jedi)
        {
            _DataAccess.deleteJedi(jedi);
        }

        void deleteMatch(Match match)
        {
            _DataAccess.deleteMatch(match);
        }

        void deleteStade(Stade stade)
        {
            _DataAccess.deleteStade(stade);
        }

        public static DalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _ instance = new DalManager();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
