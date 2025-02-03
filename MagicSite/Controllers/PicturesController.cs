using MagicSite.Data.UnitOfWork;
using MagicSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IConfiguration _config;

        public PicturesController(IUnitOfWork unit, IConfiguration config)
        {
            _unit = unit;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult> AddImage(Prod_ImageTbl image)
        {

            var MaxSize = _config.GetValue<long>("ImageUploads: AllowedMaxSize");

            //Checking if variable is not empty basically it is validation.
           if(image.image == null || image.image.Length == 0)
            {
                throw new ArgumentException("No File uploaded");
            }


           //Checking File SIze
            if (image.image.Length > MaxSize)
            {
                throw new ArgumentException("File too large");
            }


            //Checking file extention to ensure it is an Image
            var allowedExtentions = _config.GetValue<string>("ImageUploads:FileExtentions").Split(", ");
            
            var GetExtention = Path.GetExtension(image.image.FileName).ToLower();

            if (!allowedExtentions.Contains(GetExtention))
            {
                throw new ArgumentException("Wrong file extention");
            }



            //Prepare URL
            // var uploadPath = Path.Combine(_config[""])
            var UploadPath = _config["ImageUploads:UploadPathMenShoes"];

            //Generate unique name
            var UniqueName = Guid.NewGuid().ToString() +image.image.FileName + GetExtention;
            var filePath = Path.Combine(UploadPath, UniqueName);

            var file = image.image;
            //uploading image
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            //Uploading details to Database
            image.Image_Url = filePath;

            var resp = _unit.ProdImage.Add(image);

            return Ok();
        }
    }
}
