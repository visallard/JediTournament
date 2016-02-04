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

        private Match SqlDataReaderToMatch(SqlDataReader sqlDataReader)
        {
            Stade stade = GetStade(sqlDataReader.GetInt32(MATCH_STADE));
            Jedi jedi1 = GetJedi(sqlDataReader.GetInt32(MATCH_JEDI_1));
            Jedi jedi2 = GetJedi(sqlDataReader.GetInt32(MATCH_JEDI_2));
            Jedi vainqueur = null;
            if (jedi1.ID == sqlDataReader.GetInt32(MATCH_VAINQUEUR))
            {
                vainqueur = jedi1;
            }
            else if (jedi2.ID == sqlDataReader.GetInt32(MATCH_VAINQUEUR))
            {
                vainqueur = jedi2;
            }
            return new Match(sqlDataReader.GetInt32(MATCH_ID), vainqueur, jedi1, jedi2, (EPhaseTournoi) sqlDataReader.GetInt32(MATCH_PHASE_TOURNOI), stade);
        }

        public List<Match> GetMatchs(int idTournoi = 0)
        {
            List<Match> matchs = new List<Match>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Jedi1, Jedi2, PhaseTournoi, Stade, Vainqueur FROM Match";
                if (idTournoi != 0)
                    query += " WHERE Tournois=@tournois";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                if (idTournoi != 0)
                    sqlCommand.Parameters.AddWithValue("@tournoi", idTournoi);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    matchs.Add(SqlDataReaderToMatch(sqlDataReader));
                }
                sqlConnection.Close();
            }
            return matchs;
        }

        public Match GetMatch(int Id)
        {
            Match match = null;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Jedi1, Jedi2, PhaseTournoi, Stade, Vainqueur FROM Match WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    match=SqlDataReaderToMatch(sqlDataReader);
                }
                sqlConnection.Close();
            }
            return match;
        }

        public void AddMatch(Match match)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Match (Jedi1, Jedi2, PhaseTournoi, Stade, Vainqueur) VALUES (@jedi1, @jedi2, @phaseTournoi, @stade, @vainqueur); SELECT SCOPE_IDENTITY();";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@jedi1", match.Jedi1.ID);
                sqlCommand.Parameters.AddWithValue("@jedi2", match.Jedi2.ID);
                sqlCommand.Parameters.AddWithValue("@phaseTournoi", (int)match.PhaseTournoi);
                sqlCommand.Parameters.AddWithValue("@stade", match.Stade.ID);
                sqlCommand.Parameters.AddWithValue("@vainqueur", match.Vainqueur.ID);
                sqlConnection.Open();
                match.ID=sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        
        public void DeleteMatch(Match match)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Match WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", match.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        
        public void UpdateMatch(Match match)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Match SET Jedi1=@jedi1, Jedi2=@jedi2, PhaseTournoi=@phaseTournoi, Stade=@stade, Vainqueur=@vainqueur WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@jedi1", match.Jedi1.ID);
                sqlCommand.Parameters.AddWithValue("@jedi2", match.Jedi2.ID);
                sqlCommand.Parameters.AddWithValue("@phaseTournoi", (int)match.PhaseTournoi);
                sqlCommand.Parameters.AddWithValue("@stade", match.Stade.ID);
                sqlCommand.Parameters.AddWithValue("@vainqueur", match.Vainqueur.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
