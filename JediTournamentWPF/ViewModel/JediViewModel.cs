using JediTournamentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentWPF.ViewModel
{
    class JediViewModel : ViewModelBase
    {
        // Model encapsulé dans le ViewModel
        private Jedi _jedi;

        public Jedi Jedi
        {
            get { return _jedi; }
            private set { _jedi = value; }
        }

        public JediViewModel(Jedi jediModel)
        {
            _jedi = jediModel;
        }

        public string Condition
        {
            get { return ((_jedi.IsSith) ? "Sith" : "Jedi"); }
        }

        public string Nom
        {
            get { return _jedi.Nom; }
            set
            {
                if (value == _jedi.Nom) return;
                _jedi.Nom = value;
                base.OnPropertyChanged("Nom");
            }
        }

       
    }
}
