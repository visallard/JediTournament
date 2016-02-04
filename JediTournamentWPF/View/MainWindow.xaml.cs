using JediTournamentEntities;
using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

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
            //listView.ItemsSource = tm.GetCaracteristiques();
        }

        private void buttonBonus_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = tm.GetSiths();
        }

        private void buttonExporter_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xml";
            sfd.FileName = "jedis.xml";
            sfd.Filter = "XML File (*.xml)|*.xml";
            if (sfd.ShowDialog(this) == true)
            {
                StreamWriter stream = new StreamWriter(sfd.FileName);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Jedi>));
                serializer.Serialize(stream, tm.GetJedis());
                stream.Close();
            }
        }
    }
}
