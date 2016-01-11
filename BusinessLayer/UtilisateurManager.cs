using JediTournamentEntities;
using StubDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UtilisateurManager
    {
        DalManager _dal;
        public UtilisateurManager()
        {
            _dal=new DalManager();
        }

        public bool CheckConnexionUser(string login, string password) {
            Utilisateur utilisateur = _dal.GetUtilisateurByLogin(login);
            return (utilisateur!=null && utilisateur.Password == password);
        }
    }
}
