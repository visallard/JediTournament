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
        Jedi GetJedi(int Id);
        Match GetMatch(int Id);
        Stade GetStade(int Id);

        List<Jedi> GetJedis();
        List<Match> GetMatchs();
        List<Stade> GetStades();

        void AddJedi(Jedi jedi);
        void AddMatch(Match match);
        void AddStade(Stade stade);

        void UpdateJedi(Jedi jedi);
        void UpdateMatch(Match match);
        void UpdateStade(Stade stade);

        void DeleteJedi(Jedi jedi);
        void DeleteMatch(Match match);
        void DeleteStade(Stade stade);
    }
}
