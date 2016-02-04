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
        
        public StadesModelView(IEnumerable<Stade> stadeModel)
        {
            _stades = new ObservableCollection<Stade>();
            foreach (Stade j in stadeModel)
            {
                _stades.Add(j);
            }
        }
    }
}
