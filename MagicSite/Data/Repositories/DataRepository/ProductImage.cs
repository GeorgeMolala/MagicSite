using Dapper;
using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class ProductImage : IProdImage
    {
        private readonly DataBaseConnection _con;

        public ProductImage(DataBaseConnection con)
        {
            _con = con;
        }

        public Task<int> Add(Prod_ImageTbl entity)
        {
           var StoredProcedure = "AddProductImage_PDO";

            using(var connection = _con.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Prod_Image_ID", entity.Prod_Image_ID, DbType.Int32);
                parameters.Add("Prod_ID", entity.Prod_ID, DbType.Int32);
                parameters.Add("ImageName", entity.ImageName, DbType.String);
                parameters.Add("Image_Url", entity.Image_Url, DbType.String);


                var resp = connection.ExecuteAsync(StoredProcedure, parameters, commandType:CommandType.StoredProcedure);

                return resp;
            }
        }

     

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prod_ImageTbl>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Prod_ImageTbl> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Prod_ImageTbl entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SoftDelete(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
