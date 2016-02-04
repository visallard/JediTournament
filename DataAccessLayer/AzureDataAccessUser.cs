using System;
using System.Collections.Generic;
using JediTournamentEntities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    partial class AzureDataAccess
    {
        private const int USER_ID = 0;
        private const int USER_NOM = 1;
        private const int USER_PRENOM = 2;
        private const int USER_LOGIN = 3;
        private const int USER_PASSWORD = 4;

        private Utilisateur SqlDataReaderToUser(SqlDataReader sqlDataReader)
        {
            return new Utilisateur(sqlDataReader.GetInt32(USER_ID), sqlDataReader.GetString(USER_LOGIN), sqlDataReader.GetString(USER_PASSWORD), sqlDataReader.GetString(USER_NOM), sqlDataReader.GetString(USER_PRENOM));
        }

        public Utilisateur GetUser(string login)
        {
            Utilisateur user = null;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Nom, Prenom, Login, Password FROM User WHERE Login=@login";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@login", login);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    user = SqlDataReaderToUser(sqlDataReader);
                }
                sqlConnection.Close();
            }
            return user;
        }

        public void AddUser(Utilisateur user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO User (Nom, Prenom, Login, Password) VALUES (@nom, @prenom, @login, @password)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nom", user.Nom);
                sqlCommand.Parameters.AddWithValue("@prenom", user.Prenom);
                sqlCommand.Parameters.AddWithValue("@login", user.Login);
                sqlCommand.Parameters.AddWithValue("@password", user.Password);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT IDENT_CURRENT(‘User’)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    user.ID = sqlDataReader.GetInt32(JEDI_ID);
                }
                sqlConnection.Close();
            }
        }
    }
}
