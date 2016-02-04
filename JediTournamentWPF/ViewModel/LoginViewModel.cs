using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JediTournamentWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private Window _window;

        private string _login;
        public string Login
        {
            get { return _login; }
            private set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            private set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginViewModel(Window w)
        {
            _window = w;
            Login = string.Empty;
            Password = string.Empty;
        }

        private RelayCommand _LoginCommand;
        public System.Windows.Input.ICommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new RelayCommand(
                        () => this.LoginIn(),
                        () => this.CanLoginIn()
                        );
                }
                return _LoginCommand;
            }
        }

        private void LoginIn()
        {
            UtilisateurManager um = new UtilisateurManager();
            if (um.CheckConnexionUser(Login.ToLower(), Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                _window.Close();
            }
            else
            {
                Login = "";
                Password = "";
            }
        }

        private bool CanLoginIn()
        {
            return (Login != string.Empty && Password != string.Empty);
        }

        private RelayCommand _SigninCommand;
        public System.Windows.Input.ICommand SigninCommand
        {
            get
            {
                if (_SigninCommand == null)
                {
                    _SigninCommand = new RelayCommand(
                        () => this.Signin(),
                        () => this.CanLoginIn()
                        );
                }
                return _SigninCommand;
            }
        }

        private void Signin()
        {
            UtilisateurManager um = new UtilisateurManager();
            um.AddUser(Login, Password);
        }
    }
}
