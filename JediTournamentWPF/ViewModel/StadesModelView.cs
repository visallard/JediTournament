using BusinessLayer;
using JediTournamentEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    class StadesModelView : ViewModelBase
    {
        private ObservableCollection<Stade> _stades;
        public ObservableCollection<Stade> Stades
        {
            get { return _stades; }
            private set
            {
                _stades = value;
                OnPropertyChanged("Stades");
            }
        }

        private StadeControlModelView _selectedItem;

        public StadeControlModelView selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        
        public StadesModelView(IEnumerable<Stade> stadeModel)
        {
            _stades = new ObservableCollection<Stade>();
            foreach (Stade j in stadeModel)
            {
                _stades.Add(j);
            }
        }

        // Command Add
        private RelayCommand _AddCommand;
        
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if(_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _AddCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
        }
    }
}
