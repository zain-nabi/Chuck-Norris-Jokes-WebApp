using Chuck_Norris_Web_Application.Models;
using Chuck_Norris_Web_Application.RestApi_Helper;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chuck_Norris_Web_Application.Url_Helper
{
    public class ChuckNorrisJokesRouting
    {

        public static async Task<ChuckNorrisViewModel> GetJokePerCategory(string category)
        {
            return await RestApiHelper.GetAsync<ChuckNorrisViewModel>(new Uri(Url_Helper.UrlHelper.Api.ChuckNorrisApi, $"random?category={category}"));
        }
    }
}
