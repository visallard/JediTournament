using JediTournamentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessLayer;

namespace Web_service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
    
        [OperationContract]
        IEnumerable<Jedi> GetJedi();
        [OperationContract]
        IEnumerable<Match> GetMatch();
        [OperationContract]
        IEnumerable<Stade> GetStade();
        [OperationContract]
        IEnumerable<Tournoi> GetTournoi();


        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        //JediTournamentManager manager;

        IEnumerable<Jedi> jedis;
        IEnumerable<Match> matchs;
        IEnumerable<Stade> stades;
        IEnumerable<Tournoi> tournois;

        [DataMember]
        public IEnumerable<Jedi> Jedis
        {
            get { return jedis; }
            set { jedis = value; }
        }

        public IEnumerable<Match> Matchs
        {
            get { return matchs; }
            set { matchs = value; }
        }

        public IEnumerable<Stade> Stades
        {
            get { return stades; }
            set { stades = value; }
        }

        public IEnumerable<Tournoi> Tournois
        {
            get { return tournois; }
            set { tournois = value; }
        }
    }
}
