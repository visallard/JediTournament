using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;
using JediTournamentEntities;

namespace BusinessLayer
{
    public class JediTournamentManager
    {
        DalManager _dal;
        public JediTournamentManager()
        {
            _dal=new DalManager();
        }

        public List<string> GetStades()
        {
            List<string> liste = new List<string>();
            liste.AddRange(_dal.Stades.Select(s => s.ToString()));
            return liste;
        }

        public List<string> GetSiths()
        {
            List<string> liste = new List<string>();
            liste.AddRange(_dal.Jedis.Where(j => j.IsSith).Select(j => j.ToString()));
            return liste;
        }

        public List<string> GetJedis()
        {
            List<string> liste = new List<string>();
            liste.AddRange(_dal.Jedis.Where(j => !j.IsSith && j.Caracteristiques[EDefCaracteristique.Force]>=3 && j.Caracteristiques[EDefCaracteristique.Sante]>=50).Select(j => j.ToString()));
            return liste;
        }

        public List<string> GetMatchs()
        {
            List<string> liste = new List<string>();
            liste.AddRange(_dal.Matchs.Where(m => m.Stade.NbPlaces>200 && m.Jedi1.IsSith && m.Jedi2.IsSith).Select(m => m.ToString()));
            return liste;
        }
    }
}
