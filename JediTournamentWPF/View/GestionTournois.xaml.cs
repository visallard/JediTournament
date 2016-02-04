using BusinessLayer;
using JediTournamentEntities;
using JediTournamentWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour GestionTournois.xaml
    /// </summary>
    public partial class GestionTournois : Window
    {
        public GestionTournois()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            JediTournamentManager tm = new JediTournamentManager();
            ObservableCollection<Tournoi> tournois = new ObservableCollection<Tournoi>();
            tournois = tm.GetTournois();

            // Binding des tournois
            TournoisViewModel tvm = new TournoisViewModel(tournois);
            tournoisListView.DataContext = tvm;

            // Binding des matchs
            matchsListView.DataContext = tournoisListView.SelectedItem;

        }
    }
}
