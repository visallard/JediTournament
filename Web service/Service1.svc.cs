using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JediTournamentEntities;

namespace Web_service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public IEnumerable<Jedi> GetJedi()
        {
            BusinessLayer.JediTournamentManager m = new BusinessLayer.JediTournamentManager();
            return null;
        }

        public IEnumerable<Match> GetMatch()
        {
            BusinessLayer.JediTournamentManager m = new BusinessLayer.JediTournamentManager();
            return m.GetMatchs();
        }

        public IEnumerable<Tournoi> GetTournoi()
        {
            BusinessLayer.JediTournamentManager m = new BusinessLayer.JediTournamentManager();
            return m.GetTournois();
        }

        public IEnumerable<Stade> GetStade()
        {
            BusinessLayer.JediTournamentManager m = new BusinessLayer.JediTournamentManager();
            return m.GetStades();
        }
    }
}
