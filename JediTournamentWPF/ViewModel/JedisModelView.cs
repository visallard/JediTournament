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

        private JediViewModel _selectedItem;
        public JediViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public JedisModelView(IEnumerable<Jedi> jedisModel)
        {
            _jedis = new ObservableCollection<Jedi>();
            foreach (Jedi j in jedisModel)
            {
                _jedis.Add(j);
            }
        }

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
            JediTournamentEntities.Jedi j = new JediTournamentEntities.Jedi();

            this.SelectedItem = new JediViewModel(j);
            Jedis.Add(j);
        }
    }

}
