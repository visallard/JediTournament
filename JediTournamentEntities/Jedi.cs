using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JediTournamentEntities
{
    public class Jedi : EntityObject
    {
        public Dictionary<EDefCaracteristique, int> Caracteristiques { get; set; }
        public bool IsSith { get; set; }
        public string Nom { get; set; }

        public Jedi()
        {
            Caracteristiques = new Dictionary<EDefCaracteristique, int>();
        }

        public Jedi(int id,bool isSith,string nom)
            : base(id)
        {
            Caracteristiques = new Dictionary<EDefCaracteristique, int>();
            Caracteristiques[EDefCaracteristique.Chance] = 0;
            Caracteristiques[EDefCaracteristique.Defense] = 0;
            Caracteristiques[EDefCaracteristique.Force] = 0;
            Caracteristiques[EDefCaracteristique.Sante] = 1;
            IsSith = isSith;
            Nom = nom;
        }

        public override string ToString()
        {
            return ((IsSith) ? "Sith" : "Jedi") + " Id: " + ID + ", Nom: " + Nom + ", Force: " + Caracteristiques[EDefCaracteristique.Force] + ", Santé:" + Caracteristiques[EDefCaracteristique.Sante];
        }
    }
}
