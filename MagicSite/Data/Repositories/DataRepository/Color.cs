using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.DataRepository
{
    public class Color : IColor
    {
        public Task<int> Add(ColorTbl entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ColorTbl> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ColorTbl> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> SoftDelete(ColorTbl color)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ColorTbl entity)
        {
            throw new NotImplementedException();
        }
    }
}
