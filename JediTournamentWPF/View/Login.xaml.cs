using BusinessLayer;
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

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void SeConnecter(object sender, RoutedEventArgs e)
        {
            UtilisateurManager um = new UtilisateurManager();
            if (um.CheckConnexionUser(login.Text.ToLower(), password.Password))
            {
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loginWindow.DataContext = new LoginViewModel();
        }
    }
}
