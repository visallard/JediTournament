using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JediTournamentEntities;
using System.Data.SqlClient;
using System.Data;
using System.Security;

namespace DataAccessLayer
{
    partial class AzureDataAccess
    {
        private const int MATCH_ID = 0;
        private const int MATCH_JEDI_1 = 1;
        private const int MATCH_JEDI_2 = 2;
        private const int MATCH_PHASE_TOURNOI = 3;
        private const int MATCH_STADE = 4;
        private const int MATCH_VAINQUEUR = 5;

        public List<Match> GetMatchs()
        {
            List<Match> matchs = new List<Match>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Jedi1, Jedi2, PhaseTournoi, Stade, Vainqueur FROM Match";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Match match = new Match();

                    //matchs.Add(new Match(sqlDataReader.GetInt32(MATCH_ID), sqlDataReader.GetString(MATCH_JEDI_1), sqlDataReader.GetBoolean(JEDI_IS_SITH)));
                }
                sqlConnection.Close();
            }
            return matchs;
        }


        public Match GetMatch(int Id)
        {
            throw new NotImplementedException();
        }

        public void AddMatch(Match match)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteMatch(Match match)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateMatch(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
