using Dapper;
using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Data.Services;
using MagicSite.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class Products : IProduct
    {
        private readonly IConfiguration _config;
        private readonly DataBaseConnection _con;

        public Products(IConfiguration config, DataBaseConnection con)
        {
            _config = config;
            _con = con;
        }        

        public  Task<int> Add(ProductTbl entity)
        {

            string ProcedureName = "AddProduct_PDO";


            var parameters = new DynamicParameters();
            parameters.Add("Prod_ID", entity.Prod_ID, DbType.Int32);
            parameters.Add("ProdName", entity.ProdName, DbType.String);
            parameters.Add("ProdDescription", entity.ProdDescription, DbType.String);
            parameters.Add("ProdPrice", entity.ProdPrice, DbType.Double);
            parameters.Add("Cat_ID", entity.Cat_ID, DbType.Int32);
            parameters.Add("ProdSize", entity.ProdSize, DbType.String);
            parameters.Add("Color_ID", entity.Color_ID, DbType.Int32);
            parameters.Add("Brand_ID", entity.Brand_ID, DbType.Int32);

            using (var connection = _con.CreateConnection())
            {


               var ress = connection.QueryAsync(ProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return ress;
            }

            
           

        }

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTbl> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductTbl> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> SoftDelete(ProductTbl product)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductTbl entity)
        {
            throw new NotImplementedException();
        }
    }
}
