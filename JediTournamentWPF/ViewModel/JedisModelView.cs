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
    class JedisModelView : ViewModelBase
    {
        private ObservableCollection<Jedi> _jedis;
        public ObservableCollection<Jedi> Jedis
        {
            get { return _jedis; }
            private set
            {
                _jedis = value;
                OnPropertyChanged("Jedis");
            }
        }

        public JedisModelView(List<Jedi> jedisModel)
        {
            _jedis = new ObservableCollection<Jedi>();
            foreach (Jedi j in jedisModel)
            {
                _jedis.Add(j);
            }
        }
    }
}
