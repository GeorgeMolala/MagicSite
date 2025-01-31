using MagicSite.Data.Repositories.DataRepository;
using MagicSite.Data.Repositories.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProduct Products { get; }

        IBrand Brand { get; }

        ICategory Category { get; }

        IColor Color { get; }

        IProdImage ProdImage { get;}


    }
}
