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
        public List<ViewProductHighLights> products { get; set; }

        private readonly IUnitOfWork _unit;
        private readonly IConfiguration _config;
        

        public ViewModelProductHighLights(IUnitOfWork unit, IConfiguration config)
        {
            _unit = unit;
            _config = config;
            
           
        }

        public async Task<ActionResult<ViewModelProductHighLights>> GetProducts()
        {
            products = await _unit.ViewProductHigh.GetAll();

            return res.ToList();
        }



    }
}
