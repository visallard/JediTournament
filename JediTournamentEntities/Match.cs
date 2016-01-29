using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public class Match : EntityObject
    {
        public Jedi Vainqueur { get; set; }
        public Jedi Jedi1 { get; set; }
        public Jedi Jedi2 { get; set; }
        public EPhaseTournoi PhaseTournoi { get; set; }
        public Stade Stade { get; set; }

        public Match()
        {
        }

        public Match(int id,Jedi vainqueur,Jedi jedi1,Jedi jedi2,EPhaseTournoi phaseTournoi,Stade stade):base(id)
        {
            Vainqueur = vainqueur;
            Jedi1 = jedi1;
            Jedi2 = jedi2;
            PhaseTournoi = phaseTournoi;
            Stade = stade;
        }

        public override string ToString()
        {
            return "Match: Id: " + ID + ", Phase du tournoi: " + PhaseTournoi.ToString();
        }
    }
}
