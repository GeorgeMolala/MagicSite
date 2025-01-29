using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data
{
    public class DataBaseConnection
    {
        private readonly IConfiguration _config;
        private readonly string _con;

        public DataBaseConnection(IConfiguration config)
        {
            _config = config;
            _con = _config.GetConnectionString("DefaultConnection");
           // CreateConnection();
        }

        public IDbConnection CreateConnection() => new SqlConnection(_con);

    }
}
