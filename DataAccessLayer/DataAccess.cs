using JediTournamentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface DataAccess
    {
        List<Jedi> GetJedis();
        List<Match> GetMatchs();
        List<Stade> GetStades();

        void addJedi(Jedi jedi);
        void addMatch(Match match);
        void addStade(Stade stade);

        void updateJedi(Jedi jedi);
        void updateMatch(Match match);
        void updateStade(Stade stade);

        void deleteJedi(Jedi jedi);
        void deleteMatch(Match match);
        void deleteStade(Stade stade);
    }
}
