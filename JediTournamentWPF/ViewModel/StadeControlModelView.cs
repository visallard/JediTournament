using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    class StadeControlModelView : ViewModelBase
    {
        private JediTournamentEntities.Stade _stade;

        public JediTournamentEntities.Stade Stade
        {
            get { return _stade; }
            private set
            {
                _stade = value;
            }
        }

        public StadeControlModelView(JediTournamentEntities.Stade stadeModel)
        {
            _stade = stadeModel;
        }

        public string Planete
        {
            get { return _stade.Planete; }
            set
            {
                if (value == _stade.Planete) return;
                _stade.Planete = value;
                base.OnPropertyChanged("Planete");
            }
        }

        public int NbPlace
        {
            get { return _stade.NbPlaces; }
            set
            {
                if (value == _stade.NbPlaces) return;
                _stade.NbPlaces = value;
                base.OnPropertyChanged("NbPlace");
            }
        }
    }
}
