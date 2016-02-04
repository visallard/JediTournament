using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JediTournamentEntities;
using System.Collections.ObjectModel;

namespace JediTournamentWPF.ViewModel
{
    class TournoisViewModel : ViewModelBase
    {
        private Tournoi _SelectedItem;

        public Tournoi SelectedItem
        {
            private set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }

            get
            {
                return _SelectedItem;
            }
        }

        private ObservableCollection<Tournoi> _tournois;

        public ObservableCollection<Tournoi> Tournois
        {
            private set
            {
                _tournois = value;
                OnPropertyChanged("Tournois");
            }

            get
            {
                return _tournois;
            }
        }

        private ObservableCollection<Match> _matchs;
        public ObservableCollection<Match> Matchs
        {
            private set
            {
                _matchs = value;
                OnPropertyChanged("Matchs");
            }

            get
            {
                return _matchs;
            }
        }

        public TournoisViewModel(ObservableCollection<Tournoi> tournoisModel)
        {
            _tournois = new ObservableCollection<Tournoi>();
            foreach (Tournoi t in tournoisModel)
            {
                _tournois.Add(t);
            }
        }
    }
}
