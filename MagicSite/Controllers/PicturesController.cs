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
    //[Route("[controller]/[action]")]
    //[ApiController]
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
        public IActionResult AddingProducts()
        {
            return View();
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<ActionResult> AddImage(Prod_ImageTbl ProImage)
        {

            var MaxSize = _config.GetValue<long>("ImageUploads:AllowedMaxSize");
            var l1 = _config["ImageUploads: AllowedMaxSize"];
            
            //Checking if variable is not empty basically it is validation.
           if(ProImage.Form == null || ProImage.Form.Length == 0)
            {
                throw new ArgumentException("No File uploaded");
            }


           //Checking File SIze
            if (ProImage.Form.Length > MaxSize)
            {
                throw new ArgumentException("File too large");
            }


            //Checking file extention to ensure it is an Image
            var allowedExtentions = _config.GetValue<string>("ImageUploads:FileExtentions").Split(", ");
            
            var GetExtention = Path.GetExtension(ProImage.Form.FileName).ToLower();

            if (!allowedExtentions.Contains(GetExtention))
            {
                throw new ArgumentException("Wrong file extention");
            }



            //Prepare URL
            // var uploadPath = Path.Combine(_config[""])
            var UploadPath = "wwwroot/"+_config["ImageUploads:UploadPathMenShoes"];

            //Generate unique name
            var UniqueName = Guid.NewGuid().ToString() +ProImage.Form.FileName + GetExtention;
            var filePath = Path.Combine(UploadPath, UniqueName);

            var file = ProImage.Form;
            //uploading image
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            //Uploading details to Database
            var storageURL = Path.Combine(_config["ImageUploads:UploadPathMenShoes"], UniqueName);
            ProImage.Image_Url = storageURL;

           // ProImage.Prod_Image_ID = 4;
            var resp = _unit.ProdImage.Add(ProImage);
           
            return Ok();
        }

        [IgnoreAntiforgeryToken]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prod_ImageTbl>>> GetAllByID() //Pass INT ID
        {
            int ID = 6;

            var resp = await _unit.ProdImage.GetAllByID(ID);

           // return Json(resp);
            return  View(resp.ToList());
        } 
    }
}
