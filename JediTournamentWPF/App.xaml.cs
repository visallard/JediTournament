using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.DispatcherUnhandledException += AppDispatcherUnhandledException;
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show("Une erreur est survenue.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                LogManager.Writelog(e.Exception.ToString()); 
                e.Handled = true;
            }
            catch {}
        }
    }
}
