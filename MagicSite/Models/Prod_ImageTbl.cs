using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MagicSite.Models
{
    public class Prod_ImageTbl
    {
        [Key]
        public int Prod_Image_ID { get; set; }

        public int Prod_ID { get; set; }

        public string ImageName { get; set; }

        public IFormFile Form { get; set; }
        
    
        public string Image_Url { get; set; }
    }
}
