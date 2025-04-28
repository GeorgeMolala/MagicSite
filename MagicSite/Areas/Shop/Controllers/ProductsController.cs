using Amazon.S3;
using Amazon.S3.Model;
using MagicSite.Data.UnitOfWork;
using MagicSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;



namespace MagicSite.Areas.Shop.Controllers
{

    [Area("Shop")]
    public class ProductsController : Controller
    {


        private readonly IUnitOfWork _unit;
        private readonly IConfiguration _config;
        private readonly IAmazonS3 _client;
        private string Bucketname { get; set; } = "rossettestorage-1";

        public ProductsController(IUnitOfWork unit, IConfiguration config, IAmazonS3 client)
        {
            _unit = unit;
            _config = config;
            _client = client;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductTbl product)
        {

            try
            {
                var MaxSize = _config.GetValue<long>("ImageUploads:AllowedMaxSize");
                var l1 = _config["ImageUploads: AllowedMaxSize"];

                //Checking if variable is not empty basically it is validation.
                if (product.ImageFile == null || product.ImageFile.Length == 0)
                {
                    throw new ArgumentException("No File uploaded");
                }


                //Checking File SIze
                if (product.ImageFile.Length > MaxSize)
                {
                    throw new ArgumentException("File too large");
                }


                //Checking file extention to ensure it is an Image
                var allowedExtentions = _config.GetValue<string>("ImageUploads:FileExtentions").Split(", ");

                var GetExtention = Path.GetExtension(product.ImageFile.FileName).ToLower();

                if (!allowedExtentions.Contains(GetExtention))
                {
                    throw new ArgumentException("Wrong file extention");
                }



                //Generate unique name
                var UniqueName = Guid.NewGuid().ToString("D").Substring(0, 8) + product.ImageFile.FileName + product.ImageFile.ContentType;
                //var filePath = Path.Combine(UploadPath, UniqueName);

                var file = product.ImageFile;
                string paths = "Shoes";
                var objectToPut = new PutObjectRequest()
                {
                    BucketName = "rossettestorage-1",
                    Key = $"{paths}/{UniqueName}",
                    InputStream = product.ImageFile.OpenReadStream()

                };

                var response = await _client.PutObjectAsync(objectToPut);

                var imageUrl = $"https://{objectToPut.BucketName}.s3.amazonaws.com/{paths}/{UniqueName}";

                product.CoverName = $"{paths}/{UniqueName}";
                product.CoverURL = imageUrl;
              
            }
            catch (AmazonS3Exception ex)
            {
                return StatusCode(500, "Upload failed. Please try again.");
            }




            //Saving Data To DataBase

            try
            {
                var resp = _unit.Products.Add(product);
                return Ok(resp);
            }
            catch
            {
                try
                {
                     var UniqueName = Guid.NewGuid().ToString("D").Substring(0, 8) + product.ImageFile.FileName + product.ImageFile.ContentType;
                     var file = product.ImageFile;

                     string paths = "Shoes";
                     var objectDelete = new DeleteObjectRequest()
                        {
                           BucketName = "rossettestorage-1",
                           Key = $"{paths}/{UniqueName}",
                        };

                       await _client.DeleteObjectAsync(objectDelete);
                }
                catch (AmazonS3Exception ex)
                {
                    return StatusCode((int)ex.StatusCode, ex.Message);
                }
             

                return StatusCode(500);
            }


         
        }
    }
}
