using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chuck_Norris_Web_Application.Url_Helper
{
    public class UrlHelper
    {
        private static string GetUrl()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config.GetSection("WebApiUrl").GetSection("chuck_norris_api").Value;
        }

        public static class Api
        {
            public static Uri ChuckNorrisApi => new Uri(GetUrl());
        }
    }
}
