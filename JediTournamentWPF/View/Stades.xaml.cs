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
    /// Logique d'interaction pour Stades.xaml
    /// </summary>
    public partial class Stades : Window
    {
        public Stades()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // récupération des stades
            JediTournamentManager jm = new JediTournamentManager();
            IEnumerable<Stade> stades = jm.GetStades();

            // Initialisation du viewModel
            StadesModelView jmv = new StadesModelView(stades);
            stadesListView.DataContext = jmv;
        }
    }
}
