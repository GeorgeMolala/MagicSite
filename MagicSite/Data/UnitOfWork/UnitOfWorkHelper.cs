using MagicSite.Data.Repositories.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.UnitOfWork
{
    public class UnitOfWorkHelper:IUnitOfWork
    {
        public IProduct Products { get; set; }

        public IBrand Brand { get; set; }

        public ICategory Category { get; set; }

        public IColor Color { get; set; }

        public IProdImage ProdImage { get; set; }

        public UnitOfWorkHelper(IBrand brand, IProduct product, ICategory category, IColor color, IProdImage image)
        {
            Products = product;
            Brand = brand;
            Category = category;
            Color = color;
            ProdImage = image;

        }

       
    }
}
