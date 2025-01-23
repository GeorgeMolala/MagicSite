using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class Category : ICategory
    {
        public Task<int> Add(CategoryTbl entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryTbl> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryTbl> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> SoftDelete(CategoryTbl category)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(CategoryTbl entity)
        {
            throw new NotImplementedException();
        }
    }
}
