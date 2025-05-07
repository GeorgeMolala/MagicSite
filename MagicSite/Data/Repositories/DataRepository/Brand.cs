using Dapper;
using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class Brand : IBrand
    {

        private readonly IConfiguration _config;
        private readonly DataBaseConnection _con;

        public Brand( IConfiguration config, DataBaseConnection con)
        {
            _con = con;
            _config = config;
        }

        public Task<int> Add(BrandTbl entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

      
        public async Task<IEnumerable<BrandTbl>> GetAll()
        {
            string StoredProcedureName = "GetAllBrands_PDO";

            using (var connection = _con.CreateConnection())
            {
                connection.Open();

                var res = await connection.QueryAsync<BrandTbl>(StoredProcedureName, commandType: CommandType.StoredProcedure);

                connection.Close();


                return res.ToList();

            }
        }

        public Task<BrandTbl> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> SoftDelete(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(BrandTbl entity)
        {
            throw new NotImplementedException();
        }
    }
}
