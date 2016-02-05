using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using JediTournamentEntities;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class JediTournamentManager
    {
        public IEnumerable<Stade> GetStades()
        {
            return DalManager.Instance.GetStades();
        }

        public IEnumerable<Jedi> GetSiths()
        {
            return DalManager.Instance.GetJedis().Where(j => j.IsSith);
        }

        public IEnumerable<Jedi> GetJedis()
        {
            return DalManager.Instance.GetJedis();
        }

        public IEnumerable<Match> GetMatchs()
        {
            return DalManager.Instance.GetMatchs();
        }

        public void AddJedi(Jedi jedi)
        {
            DalManager.Instance.AddJedi(jedi);
        }

        public void DelJedi(Jedi jedi)
        {
            DalManager.Instance.DeleteJedi(jedi);
        }

        public void AddMatch(Match match)
        {
            DalManager.Instance.AddMatch(match);
        }

        public void DelMatch(Match match)
        {
            DalManager.Instance.DeleteMatch(match);
        }

        public void AddStade(Stade stade)
        {
            DalManager.Instance.AddStade(stade);
        }

        public void DelStade(Stade stade)
        {
            DalManager.Instance.DeleteStade(stade);
        }

        public void AddTournoi(Tournoi tournoi)
        {
            DalManager.Instance.AddTournoi(tournoi);
        }

        public void DelTournoi(Tournoi tournoi)
        {
            DalManager.Instance.DeleteTournoi(tournoi);
        }

        //public IEnumerable<Tournoi> GetTournois()
        public IEnumerable<Tournoi> GetTournois() // Quand tu ajoute la BBD pour les tournois décommente tes lignes et change mes "ObservableCollection" par le bon type stp
        {
            return DalManager.Instance.GetTournois();
        }
    }
}
