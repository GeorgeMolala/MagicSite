using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Models
{
    public class CategoryTbl
    {
        [Key]
        public int Cat_ID { get; set; }

        public string CatName { get; set; }

        public string CatDescription { get; set; }

    }
}
