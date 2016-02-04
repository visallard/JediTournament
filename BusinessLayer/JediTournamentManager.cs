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
            return DalManager.Instance.GetJedis().Where(j => !j.IsSith);
        }

        public IEnumerable<Match> GetMatchs()
        {
            return DalManager.Instance.GetMatchs();
        }

        public void AddJedi(Jedi jedi)
        {
            DalManager.Instance.AddJedi(jedi);
        }

        public ObservableCollection<Tournoi> GetTournois()
        {
            Stade stade1 = new Stade(1000, "Tatooine");
            Stade stade2 = new Stade(5000, "Mustafar");

            Jedi jedi1 = new Jedi(0, "Paul", false);
            Jedi jedi2 = new Jedi(0, "Julien", false);
            Jedi jedi3 = new Jedi(0, "Antoine", true);
            Jedi jedi4 = new Jedi(0, "Victor", true);
            Jedi jedi5 = new Jedi(0, "Elian", true);

            List<Match> matchs1 = new List<Match>();
            matchs1.Add(new Match(0, jedi1, jedi1, jedi2, EPhaseTournoi.DemiFinale, stade1));
            matchs1.Add(new Match(0, jedi3, jedi3, jedi4, EPhaseTournoi.DemiFinale, stade2));
            matchs1.Add(new Match(0, jedi1, jedi1, jedi3, EPhaseTournoi.Finale, stade1));

            List<Match> matchs2 = new List<Match>();
            matchs2.Add(new Match(0, jedi1, jedi1, jedi3, EPhaseTournoi.DemiFinale, stade2));
            matchs2.Add(new Match(0, jedi2, jedi2, jedi4, EPhaseTournoi.DemiFinale, stade1));
            matchs2.Add(new Match(0, jedi1, jedi1, jedi2, EPhaseTournoi.Finale, stade2));

            ObservableCollection<Tournoi> tournois = new ObservableCollection<Tournoi>();
            tournois.Add(new Tournoi(0, "TournoiDeTest", matchs1));
            tournois.Add(new Tournoi(1, "TournoiDeTest2", matchs2));

            return tournois;
        }
    }
}
