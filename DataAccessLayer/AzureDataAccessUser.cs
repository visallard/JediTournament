using System;
using System.Collections.Generic;
using JediTournamentEntities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    partial class AzureDataAccess
    {
        private const int USER_ID = 0;
        private const int USER_LOGIN = 1;
        private const int USER_PASSWORD = 2;

        private Utilisateur SqlDataReaderToUser(SqlDataReader sqlDataReader)
        {
            return new Utilisateur(sqlDataReader.GetInt32(USER_ID), sqlDataReader.GetString(USER_LOGIN), sqlDataReader.GetString(USER_PASSWORD));
        }

        public Utilisateur GetUser(string login)
        {
            Utilisateur user = null;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Login, Password FROM \"User\" WHERE Login=@login";
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
                string query = "INSERT INTO \"User\" (Login, Password) VALUES (@login, @password); SELECT SCOPE_IDENTITY();";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@login", user.Login);
                sqlCommand.Parameters.AddWithValue("@password", user.Password);
                sqlConnection.Open();
                user.ID=sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
