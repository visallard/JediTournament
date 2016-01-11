using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public class Caracteristiques : EntityObject
    {
        public string Definition { get; set; }
        public string Nom { get; set; }
        public ETypeCarecteristique Type { get; set; }
        public int Valeur { get; set; }
        public Caracteristiques(int id,string definition,string nom,ETypeCarecteristique type,int valeur)
            : base(id)
        {
            Definition = definition;
            Nom = nom;
            Type = type;
            Valeur = valeur;
        }


    }
}
