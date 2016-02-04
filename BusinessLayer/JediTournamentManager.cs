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

        //public IEnumerable<Tournoi> GetTournois()
        public ObservableCollection<Tournoi> GetTournois() // Quand tu ajoute la BBD pour les tournois décommente tes lignes et change mes "ObservableCollection" par le bon type stp
        {
            // Données pour tester le binding
            Stade stade1 = new Stade(1000, "Tatooine");
            Stade stade2 = new Stade(5000, "Mustafar");

            Jedi jedi1 = new Jedi("Paul", false);
            Jedi jedi2 = new Jedi("Julien", false);
            Jedi jedi3 = new Jedi("Antoine", true);
            Jedi jedi4 = new Jedi("Victor", true);
            Jedi jedi5 = new Jedi("Elian", true);

            List<Match> matchs1 = new List<Match>();
            matchs1.Add(new Match(0, jedi1, jedi1, jedi2, EPhaseTournoi.DemiFinale, stade1));
            matchs1.Add(new Match(1, jedi4, jedi3, jedi4, EPhaseTournoi.DemiFinale, stade2));
            matchs1.Add(new Match(2, jedi1, jedi1, jedi4, EPhaseTournoi.Finale, stade1));

            List<Match> matchs2 = new List<Match>();
            matchs2.Add(new Match(0, jedi1, jedi1, jedi3, EPhaseTournoi.DemiFinale, stade2));
            matchs2.Add(new Match(1, jedi2, jedi2, jedi4, EPhaseTournoi.DemiFinale, stade1));
            matchs2.Add(new Match(2, jedi1, jedi1, jedi2, EPhaseTournoi.Finale, stade2));

            List<Match> matchs3 = new List<Match>();
            matchs3.Add(new Match(0, jedi1, jedi1, jedi4, EPhaseTournoi.DemiFinale, stade2));
            matchs3.Add(new Match(1, jedi3, jedi2, jedi3, EPhaseTournoi.DemiFinale, stade1));
            matchs3.Add(new Match(2, jedi1, jedi1, jedi3, EPhaseTournoi.Finale, stade2));
            
            ObservableCollection<Tournoi> tournois = new ObservableCollection<Tournoi>();
            tournois.Add(new Tournoi(0, "TournoiDeTest0", matchs1));
            tournois.Add(new Tournoi(1, "TournoiDeTest1", matchs2));
            tournois.Add(new Tournoi(2, "TournoiDeTest2", matchs3));

            //return DalManager.Instance.GetTournois();
            return tournois;
        }
        public void AddStade(Stade stade)
        {
            DalManager.Instance.AddStade(stade);
        }
    }
}
