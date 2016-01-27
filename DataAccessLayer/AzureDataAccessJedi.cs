using System;
using System.Collections.Generic;
using JediTournamentEntities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    partial class AzureDataAccess
    {
        private const int JEDI_ID = 0;
        private const int JEDI_NOM = 1;
        private const int JEDI_IS_SITH = 2;

        private Jedi SqlDataReaderToJedi(SqlDataReader sqlDataReader)
        {
            return new Jedi(sqlDataReader.GetInt32(JEDI_ID), sqlDataReader.GetString(JEDI_NOM), sqlDataReader.GetBoolean(JEDI_IS_SITH));
        }

        public List<Jedi> GetJedis()
        {
            List<Jedi> jedis = new List<Jedi>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Nom, IsSith FROM Jedi";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    jedis.Add(SqlDataReaderToJedi(sqlDataReader));
                }
                sqlConnection.Close();
            }
            return jedis;
        }

        public Jedi GetJedi(int Id)
        {
            Jedi jedi=null;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = string.Format("SELECT Id, Nom, IsSith FROM Jedi WHERE Id={0}", Id);
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    jedi = SqlDataReaderToJedi(sqlDataReader);
                }
                sqlConnection.Close();
            }
            return jedi;
        }

        public void AddJedi(Jedi jedi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Jedi (Nom, IsSith) VALUES (@nom, @isSith)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nom", jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@isSith", jedi.IsSith);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void DeleteJedi(Jedi jedi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = string.Format("DELETE FROM Jedi WHERE Id=@id", jedi.ID);
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", jedi.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateJedi(Jedi jedi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Jedi SET Nom=@nom, IsSith=@isSith WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nom", jedi.Nom);
                sqlCommand.Parameters.AddWithValue("@isSith", jedi.IsSith);
                sqlCommand.Parameters.AddWithValue("@id", jedi.ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
