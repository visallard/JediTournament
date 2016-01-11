using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public class Stade : EntityObject
    {
        public List<EDefCaracteristique> Caracteristiques { get; set; }
        public int NbPlaces { get; set; }
        public string Planete { get; set; }

        public Stade(int id,int nbPlaces,string planete):base(id)
        {
            Caracteristiques = new List<EDefCaracteristique>();
            NbPlaces = nbPlaces;
            Planete = planete;
        }

        public override string ToString()
        {
            return "Stade: id:"+ID+", Nombre de places: "+NbPlaces+", Planete: " + Planete;
        }
    }
}
