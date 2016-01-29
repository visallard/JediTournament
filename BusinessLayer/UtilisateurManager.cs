using JediTournamentEntities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UtilisateurManager
    {
        public bool CheckConnexionUser(string login, string password) {
            //Utilisateur utilisateur = DalManager.Instance.GetUtilisateurByLogin(login);
            //return (utilisateur!=null && utilisateur.Password == password);
            return true;
        }
    }
}
