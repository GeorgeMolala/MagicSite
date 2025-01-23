using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Models
{
    public class BrandTbl
    {
        [Key]
        public int Brabd_ID { get; set; }

        public string Name { get; set; }
    }
}
