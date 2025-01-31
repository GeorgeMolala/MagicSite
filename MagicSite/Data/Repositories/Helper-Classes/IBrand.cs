using MagicSite.Data.Repositories.Generic_Products;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.Helper_Classes
{
    public interface IBrand : IAppRep<BrandTbl>
    {
        Task<int> SoftDelete(int ID);

    }
}
