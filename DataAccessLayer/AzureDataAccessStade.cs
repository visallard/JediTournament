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
        private const int STADE_ID = 0;
        private const int STADE_NB_PLACES = 1;
        private const int STADE_PLANETE = 2;

        private Stade SqlDataReaderToStade(SqlDataReader sqlDataReader)
        {
            return new Stade(sqlDataReader.GetInt32(STADE_ID), sqlDataReader.GetInt32(STADE_ID), sqlDataReader.GetString(STADE_PLANETE));
        }

        public List<Stade> GetStades()
        {
            List<Stade> stades = new List<Stade>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, NbPlaces, Planete FROM Stade";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    stades.Add(SqlDataReaderToStade(sqlDataReader));
                }
                sqlConnection.Close();
            }
            return stades;
        }

        public Stade GetStade(int Id)
        {
            Stade stade = null;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, NbPlaces, Planete FROM Stade WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    stade = SqlDataReaderToStade(sqlDataReader);
                }
                sqlConnection.Close();
            }
            return stade;
        }
        
        public void AddStade(Stade stade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Stade (NbPlaces, Planete) VALUES (@nbPlaces, @planete); SELECT SCOPE_IDENTITY()";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nbPlaces", stade.NbPlaces);
                sqlCommand.Parameters.AddWithValue("@planete", stade.Planete);
                sqlConnection.Open();
                stade.ID= System.Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlConnection.Close();
            }
        }

        public void DeleteStade(Stade stade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Stade WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", stade.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateStade(Stade stade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Stade SET NbPlaces=@nbPlaces, Planete=@planete WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nbPlaces", stade.NbPlaces);
                sqlCommand.Parameters.AddWithValue("@planete", stade.Planete);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
