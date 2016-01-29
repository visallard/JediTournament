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
        private const int TOURNOI_ID = 0;
        private const int TOURNOI_NOM = 1;

        private Tournoi SqlDataReaderToTournoi(SqlDataReader sqlDataReader)
        {
            return new Tournoi(sqlDataReader.GetInt32(TOURNOI_ID),sqlDataReader.GetString(TOURNOI_NOM), GetMatchs(sqlDataReader.GetInt32(TOURNOI_ID)));
        }

        public void AddTournoi(Tournoi tournoi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Tournoi (Nom) VALUES (@nom)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nom", tournoi.Nom);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT IDENT_CURRENT(‘Tournoi’)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    tournoi.ID = sqlDataReader.GetInt32(STADE_ID);
                }
                sqlConnection.Close();
            }
            // ajouter les matchs
        }

        public void DeleteTournoi(Tournoi tournoi)
        {
            foreach (Match m in tournoi.Matchs)
                DeleteMatch(m);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Tournoi WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", tournoi.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public Tournoi GetTournoi(int Id)
        {
            Tournoi tournoi = null;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Nom FROM Tournois WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    tournoi = SqlDataReaderToTournoi(sqlDataReader);
                }
                sqlConnection.Close();
            }
            return tournoi;
        }

        public List<Tournoi> GetTournois()
        {
            List<Tournoi> tournois = new List<Tournoi>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Nom FROM Tournois";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    tournois.Add(SqlDataReaderToTournoi(sqlDataReader));
                }
                sqlConnection.Close();
            }
            return tournois;
        }

        public void UpdateTournoi(Tournoi tournoi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Tournoi SET Nom=@nom WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nom", tournoi.Nom);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            // ajouter les matchs
        }
    }
}
