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
        public event EventHandler<EventArgs> CloseNotified;
        protected void OnCloseNotified(EventArgs e)
        {
            this.CloseNotified(this, e);
        }

        //private ObservableCollection<JediViewModel> _jedis;
        //public ObservableCollection<JediViewModel> Jedis
        //{
        //    get { return _jedis; }
        //    private set
        //    {
        //        _jedis = value;
        //        OnPropertyChanged("Jedis");
        //    }
        //}

        //private JediViewModel _selectedItem;
        //public JediViewModel SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set
        //    {
        //        _selectedItem = value;
        //        OnPropertyChanged("SelectedItem");
        //    }
        //}

        //public JedisModelView(IEnumerable<Jedi> jedisModel)
        //{
        //    _jedis = new ObservableCollection<JediViewModel>();
        //    foreach (Jedi j in jedisModel)
        //    {
        //        _jedis.Add(new JediViewModel(j));
        //    }
        //}
    }
}
