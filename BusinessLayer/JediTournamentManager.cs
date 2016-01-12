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

        public List<Stade> GetStades()
        {
            List<Stade> liste = new List<Stade>();
            liste.AddRange(_dal.Stades);
            return liste;
        }

        public List<EDefCaracteristique> GetCaracteristiques()
        {
            List<EDefCaracteristique> liste = new List<EDefCaracteristique>();
            liste.AddRange(_dal.Caracteristiques);
            return liste;
        }

        public List<Jedi> GetSiths()
        {
            List<Jedi> liste = new List<Jedi>();
            liste.AddRange(_dal.Jedis.Where(j => j.IsSith));
            return liste;
        }

        public List<Jedi> GetJedis()
        {
            List<Jedi> liste = new List<Jedi>();
            liste.AddRange(_dal.Jedis.Where(j => !j.IsSith && j.Caracteristiques.Find(c => c.Definition==EDefCaracteristique.Force).Valeur>=3 && j.Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Sante).Valeur >= 50));
            return liste;
        }

        public List<Match> GetMatchs()
        {
            List<Match> liste = new List<Match>();
            liste.AddRange(_dal.Matchs.Where(m => m.Stade.NbPlaces>200 && m.Jedi1.IsSith && m.Jedi2.IsSith));
            return liste;
        }
    }
}
