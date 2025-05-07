using Amazon.S3;
using MagicSite.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Models.ViewModels
{
    public class ViewModelProductHighLights
    {      
        public IEnumerable<ViewProductHighLights> products { get; set; }
        public IEnumerable<BrandTbl> Brands { get; set; }
        

        private readonly IUnitOfWork _unit;
        private readonly IConfiguration _config;

        public ViewModelProductHighLights()
        {

        }

        public ViewModelProductHighLights(IUnitOfWork unit, IConfiguration config)
        {
            _unit = unit;
            _config = config;
            
           
        }

        public async Task<ActionResult<ViewModelProductHighLights>> GetProducts()
        {
            var res = await _unit.ViewProductHigh.GetAll();

            this.products = res.ToList();

            return this;            
        }



    }
}
