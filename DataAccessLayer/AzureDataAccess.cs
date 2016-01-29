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
    partial class AzureDataAccess : DataAccess
    {
        private string _connectionString = "Data Source=jeditournament.database.windows.net;Initial Catalog=\"Jedi Tournament\";Integrated Security=False;User ID=anakin;Password=Skywalker63;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
