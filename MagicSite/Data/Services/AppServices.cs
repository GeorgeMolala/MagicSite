using Amazon.S3;
using MagicSite.Data.Repositories.DataRepository;
using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Data.Services
{
    public static class AppServices
    {

        public static void AppService(this IServiceCollection service)
        {

            // service.AddSingleton<DataBaseConnection>();
            service.AddTransient<IProduct, Products>();
            service.AddTransient<IBrand, Brand>();
            service.AddTransient<ICategory, Category>();
            service.AddTransient<IColor, Color>();
            service.AddTransient<IProdImage, ProductImage>();
            service.AddTransient<IUnitOfWork, UnitOfWorkHelper>();
            service.AddAWSService<IAmazonS3>();
            service.AddTransient<IViewProductHigh, ViewProductHigh>();


        }


    }
}
