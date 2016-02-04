using JediTournamentEntities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class UtilisateurManager
    {
        public bool CheckConnexionUser(string login, string password)
        {
            Utilisateur user = DalManager.Instance.GetUser(login);
            return (user != null && user.Password == HashPassword(password));
        }

        public void AddUser(string login, string password) {
            password = HashPassword(password);
            DalManager.Instance.AddUser(new Utilisateur(login, password));
        }

        private string HashPassword(string password)
        {
            SHA512 shaM = new SHA512Managed();
            var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder strB = new StringBuilder();
            for(int i=0; i< hash.Length; ++i)
            {
                strB.Append(hash[i].ToString());
            }
            return strB.ToString();
        }
    }
}
