using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class Products : IProduct
    {

        public Task<int> Add(ProductTbl entity)
        {
            throw new NotImplementedException();
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
