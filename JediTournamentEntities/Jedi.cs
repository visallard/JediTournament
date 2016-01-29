using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JediTournamentEntities
{
    [Serializable]
    public class Jedi : EntityObject
    {
        public List<Caracteristique> Caracteristiques { get; set; }
        public bool IsSith { get; set; }
        public string Nom { get; set; }

        public Jedi()
        {
            Caracteristiques = new List<Caracteristique>();
        }

        public Jedi(string nom, bool isSith) : this(0, nom, isSith)
        {
            Caracteristiques = new List<Caracteristique>();
        }

        public Jedi(int id,string nom, bool isSith)
            : base(id)
        {
            Caracteristiques = new List<Caracteristique>();
            Caracteristiques.Add(new Caracteristique(1, EDefCaracteristique.Chance, "Chance", ETypeCarecteristique.Jedi, 0));
            Caracteristiques.Add(new Caracteristique(2, EDefCaracteristique.Defense, "Defense", ETypeCarecteristique.Jedi, 0));
            Caracteristiques.Add(new Caracteristique(3, EDefCaracteristique.Force, "Force", ETypeCarecteristique.Jedi, 0));
            Caracteristiques.Add(new Caracteristique(4, EDefCaracteristique.Sante, "Sante", ETypeCarecteristique.Jedi, 0));
            IsSith = isSith;
            Nom = nom;
        }

        public override string ToString()
        {
            return ((IsSith) ? "Sith" : "Jedi") + " Id: " + ID + ", Nom: " + Nom + ", Force: " + Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Force) + ", Santé:" + Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Sante);
        }
    }
}
