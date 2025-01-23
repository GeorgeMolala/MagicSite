using MagicSite.Data.Repositories.Generic_Products;
using MagicSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Repositories.Helper_Classes
{
    public interface IColor : IAppRep<ColorTbl>
    {
        Task<int> SoftDelete(ColorTbl color);
    }
}
