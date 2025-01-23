using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Models
{
    public class ColorTbl
    {
        [Key]
        public int Color_ID { get; set; }

        public string Name { get; set; }

        public string Color_Code { get; set; }
    }
}
