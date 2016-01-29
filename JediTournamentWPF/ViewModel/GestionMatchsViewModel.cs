using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace JediTournamentWPF.ViewModel
{
    class GestionMatchsViewModel : ViewModelBase
    {
        // Event destiné à réclamer la fermeture du conteneur;
        public event EventHandler<EventArgs> CloseNotified;
        protected void OnCloseNotified(EventArgs e)
        {
            this.CloseNotified(this, e);
        }

        // Model encapsulé dans le ViewModel
        private ObservableCollection<GestionMatchsViewModel> _matchs;
        public ObservableCollection<GestionMatchsViewModel> Matchs
        {
            get { return _matchs; }
            private set
            {
                _matchs = value;
                OnPropertyChanged("Matchs");
            }
        }

        private GestionMatchsViewModel _selectedItem;
        public GestionMatchsViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public GestionMatchsViewModel(IList<JediTournamentEntities.Match> matchesModel)
        {
            _matchs = new ObservableCollection<GestionMatchsViewModel>();
            foreach (JediTournamentEntities.Match a in matchesModel)
            {
                _matchs.Add(new GestionMatchsViewModel(a));
            }
        }

        // Commande Add
        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            JediTournamentEntities.Match a = new JediTournamentEntities.Match();

            this.SelectedItem = new GestionMatchsViewModel(a);
            Matchs.Add(this.SelectedItem);
        }

        // Commande Remove
        private RelayCommand _removeCommand;
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return _removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedItem != null);
        }

        private void Remove()
        {
            if (this.SelectedItem != null) Matchs.Remove(this.SelectedItem);
        }

        // Model encapsulé dans le ViewModel
        private JediTournamentEntities.Match _match;

        public JediTournamentEntities.Match Match
        {
            get { return _match; }
            private set { _match = value; }
        }

        public GestionMatchsViewModel(JediTournamentEntities.Match MatchModel)
        {
            _match = MatchModel;
        }

        #region "Propriétés accessibles, mappables par la View"

        public JediTournamentEntities.Jedi Vainqueur
        {
            get { return _match.Vainqueur; }
            set 
            {
                if (value == _match.Vainqueur) return;
                _match.Vainqueur = value;
                base.OnPropertyChanged("Vainqueur");
            }
        }

        public JediTournamentEntities.Jedi Jedi1
        {
            get { return _match.Jedi1; }
            set 
            {
                if (value == _match.Jedi1) return;
                _match.Jedi1 = value;
                base.OnPropertyChanged("Jedi1");
            }
        }

        public JediTournamentEntities.Jedi Jedi2
        {
            get { return _match.Jedi2; }
            set 
            {
                if (value == _match.Jedi2) return;
                _match.Jedi2 = value;
                base.OnPropertyChanged("Jedi2");
            }
        }

        public JediTournamentEntities.EPhaseTournoi PhaseTournoi
        {
            get { return _match.PhaseTournoi; }
            set 
            {
                if (value == _match.PhaseTournoi) return;
                _match.PhaseTournoi = value;
                base.OnPropertyChanged("PhaseTournoi");
            }
        }

        public JediTournamentEntities.Stade Stade
        {
            get { return _match.Stade; }
            set
            {
                if (value == _match.Stade) return;
                _match.Stade = value;
                base.OnPropertyChanged("Stade");
            }
        }

        #endregion
    }
}
