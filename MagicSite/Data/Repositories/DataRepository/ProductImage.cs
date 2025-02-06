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

        public async Task<int> Add(Prod_ImageTbl entity)
        {
           var StoredProcedure = "AddProductImage_PDO";

            var parameters = new DynamicParameters();
           // parameters.Add("Prod_Image_ID", entity.Prod_Image_ID, DbType.Int32);
            parameters.Add("Prod_ID", entity.Prod_ID, DbType.Int32);
            parameters.Add("ImageName", entity.ImageName, DbType.String);
            parameters.Add("Image_Url", entity.Image_Url, DbType.String);

            using (var connection = _con.CreateConnection())
        {

                connection.Open();

                var resp = await connection.ExecuteAsync(StoredProcedure, parameters, commandType:CommandType.StoredProcedure);

                connection.Close();

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

        public async Task<Prod_ImageTbl> GetByID(int ID)
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

        public async Task<IEnumerable<Prod_ImageTbl>> GetAllByID(int ID)
        {
            var StoredProcedure = "GetImageByID_PDO";

            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32);

            using (var connection = _con.CreateConnection())
            {
                connection.Open();

               
                var res = await connection.QueryAsync<Prod_ImageTbl>(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
                
                connection.Close();

                return res.ToList();
            }
            
        }
    }
}
