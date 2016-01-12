using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JediTournamentEntities
{
    [Serializable]
    public class Caracteristique : EntityObject
    {
        public EDefCaracteristique Definition { get; set; }
        public string Nom { get; set; }
        public ETypeCarecteristique Type { get; set; }
        public int Valeur { get; set; }

        public Caracteristique() : base() {}

        public Caracteristique(int id, EDefCaracteristique definition,string nom,ETypeCarecteristique type,int valeur)
            : base(id)
        {
            Definition = definition;
            Nom = nom;
            Type = type;
            Valeur = valeur;
        }


    }
}
