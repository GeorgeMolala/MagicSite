using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Models
{
    public class ProductTbl
    {
        [Key]
        public int Prod_ID { get; set; }

        public string ProdName { get; set; }

        public string ProdDescription { get; set; }

        public string ProdPrice { get; set; }

        public int Cat_ID { get; set; }


        public string ProdSize { get; set; }

        public int Color_ID { get; set; }

        public int Brand_ID { get; set; }


    }
}
