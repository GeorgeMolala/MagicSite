using Amazon.S3;
using Amazon.S3.Model;
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
        private readonly IAmazonS3 _client;
        private string Bucketname { get; set; } = "rossettestorage-1";

        public PicturesController(IUnitOfWork unit, IConfiguration config, IAmazonS3 client)
        {
            _unit = unit;
            _config = config;
            _client = client;
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

            try
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


            //Generate unique name
            var UniqueName = Guid.NewGuid().ToString("D").Substring(0, 8) + ProImage.Form.FileName + ProImage.Form.ContentType;
            //var filePath = Path.Combine(UploadPath, UniqueName);

            var file = ProImage.Form;
            string paths = "Shoes";
            var objectToPut = new PutObjectRequest()
            {
                BucketName = "rossettestorage-1",
                Key = $"{paths}/{UniqueName}",
                InputStream = ProImage.Form.OpenReadStream()

            };

            var response = await _client.PutObjectAsync(objectToPut);

            var imageUrl = $"https://{objectToPut.BucketName}.s3.amazonaws.com/{paths}/{UniqueName}";

                ProImage.ImageName = $"{paths}/{UniqueName}";
                ProImage.Image_Url = imageUrl;
                ProImage.Prod_Image_ID = 4;
            }
            catch (AmazonS3Exception ex)
            {
                return StatusCode(500, "Upload failed. Please try again.");
            }




            //Saving Data To DataBase

            try {
                var resp = _unit.ProdImage.Add(ProImage);
                return Ok(resp);
            }
            catch
            {
                return StatusCode(500);
            }

            

            
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
