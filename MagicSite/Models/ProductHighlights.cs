using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Models
{
    public class ProductHighlights
    {
        [Key]
        public int highLight_ID { get; set; }

       
        public int Prod_ID { get; set; }
        public ProductTbl ProductTbl { get; set; }
    }
}
