using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public class Tournoi : EntityObject
    {
        public List<Match> Matchs { get; set; }
        public string Nom { get; set; }
        public Tournoi(int id,string nom)
            : this(id, nom, new List<Match>())
        {
        }

        public Tournoi(int id, string nom, List<Match> matchs)
            : base(id)
        {
            Matchs = matchs;
            Nom = nom;
        }
    }
}
