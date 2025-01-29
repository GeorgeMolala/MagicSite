using MagicSite.Data.Repositories.DataRepository;
using MagicSite.Data.Repositories.Helper_Classes;
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

            //service.AddSingleton<DataBaseConnection>();
            service.AddTransient<IProduct, Products>();
        }

    }
}
