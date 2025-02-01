using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.Generic_Products
{
    public interface IAppRep <T> where T:class
    {

        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(int ID);

        Task<int> Add(T entity);

        Task<int> Update(T entity);

        Task<int> Delete(int ID);
        
    }
}
