using BusinessLayer;
using JediTournamentEntities;
using JediTournamentWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JediTournamentWPF.View
{
    /// <summary>
    /// Logique d'interaction pour Jedis.xaml
    /// </summary>
    public partial class Jedis : Window
    {
        public Jedis()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //// récupération des artistes
            //JediTournamentManager jm = new JediTournamentManager();
            //IEnumerable<JediTournamentEntities.Jedi> jedis = jm.GetJedis();

            //// Initialisation du viewModel
            //JedisModelView jmv = new JedisModelView(jedis);
            //jedisListView.DataContext = jmv;
        }

        private void BoutonAjout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
