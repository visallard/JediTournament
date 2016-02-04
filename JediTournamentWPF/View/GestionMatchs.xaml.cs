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
    /// Logique d'interaction pour GestionMatchs.xaml
    /// </summary>
    public partial class GestionMatchs : Window
    {

        public GestionMatchs()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // récupération des matchs
            BusinessLayer.JediTournamentManager tm = new BusinessLayer.JediTournamentManager();
            IList<JediTournamentEntities.Match> listMatches = tm.GetMatchs().ToList<JediTournamentEntities.Match>();

            // Initialisation du viewModel
            ViewModel.GestionMatchsViewModel mvm = new ViewModel.GestionMatchsViewModel(listMatches);
            gmatchsListView.DataContext = mvm;
        }

        private void listMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
