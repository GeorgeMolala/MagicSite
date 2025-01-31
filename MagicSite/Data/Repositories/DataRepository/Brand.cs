using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class Brand : IBrand
    {
        public Task<int> Add(BrandTbl entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrandTbl> GetAll()
        {
            throw new NotImplementedException();
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
