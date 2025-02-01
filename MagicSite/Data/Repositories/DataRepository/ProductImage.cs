using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class ProductImage : IProdImage
    {
        public Task<int> Add(Prod_ImageTbl entity)
        {
            throw new NotImplementedException();
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
