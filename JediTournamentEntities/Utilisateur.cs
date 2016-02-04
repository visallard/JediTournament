using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public class Utilisateur : EntityObject
    {
        public Utilisateur(int ID, string login, string password, string nom, string prenom) : base(ID)
        {
            Nom = nom;
            Prenom = prenom;
            Login = login;
            Password = password;
        }

        public Utilisateur()
        {

        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
