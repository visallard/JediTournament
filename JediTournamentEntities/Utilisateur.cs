using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public class Utilisateur : EntityObject
    {
        public Utilisateur(string login, string password) : this(0, login, password)
        {
        }

        public Utilisateur(int ID, string login, string password) : base(ID)
        {
            Login = login;
            Password = password;
        }

        public Utilisateur()
        {

        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
