using BusinessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JediTournamentManager tm;

        public MainWindow()
        {
            InitializeComponent();
            tm = new JediTournamentManager();
        }

        private void buttonStades_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = tm.GetStades();
        }

        private void buttonJedis_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = tm.GetJedis();
        }

        private void buttonMatchs_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = tm.GetMatchs();
        }

        private void buttonCaracteristiques_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = tm.GetCaracteristiques();
        }

        private void buttonBonus_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = tm.GetSiths();
        }

        private void buttonExporter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
