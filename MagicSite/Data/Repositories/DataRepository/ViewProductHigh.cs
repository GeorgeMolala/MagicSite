using Dapper;
using MagicSite.Data.Repositories.Generic_Products;
using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class ViewProductHigh : IViewProductHigh
    {


        private readonly IConfiguration _config;
        private readonly DataBaseConnection _con;

        public ViewProductHigh(IConfiguration config, DataBaseConnection con)
        {
            _config = config;
            _con = con;
        }

        public Task<int> Add(ViewProductHighLights entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ViewProductHighLights>> GetAll()
        {
            string stored = "GetHighLightsProducts_PDO";

            using (var connection = _con.CreateConnection() )
            {
                connection.Open();

                var res = await connection.QueryAsync<ViewProductHighLights>(stored, commandType: CommandType.StoredProcedure);

                connection.Close();

                return res.ToList();

            }
        }

        public Task<ViewProductHighLights> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ViewProductHighLights entity)
        {
            throw new NotImplementedException();
        }
    }
}
