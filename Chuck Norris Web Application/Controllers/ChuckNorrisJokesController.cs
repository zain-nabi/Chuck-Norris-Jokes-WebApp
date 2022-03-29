using Chuck_Norris_Web_Application.Models;
using Chuck_Norris_Web_Application.Url_Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chuck_Norris_Web_Application.Controllers
{
    public class ChuckNorrisJokesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Categories(string category = "animal")
        {


            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var url = config.GetSection("WebApiUrl").GetSection("chuck_norris_categories").Value;


                HttpClient client = new HttpClient();
                var CategoriesViewModel = new CategoriesViewModel();
                string response = await client.GetStringAsync(url);
                List<string> json = JsonConvert.DeserializeObject<List<string>>(response);
                CategoriesViewModel.Categories = new Categories();
                CategoriesViewModel.Categories.CategoriesList = json;
                if (category != null)
                {
                    CategoriesViewModel.ChuckNorrisViewModel = await ChuckNorrisJokesRouting.GetJokePerCategory(category);
                    return View(CategoriesViewModel);
                }
                else
                {
                    return View(CategoriesViewModel);
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Jokes(string category)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var url = config.GetSection("WebApiUrl").GetSection("chuck_norris_categories").Value;


            HttpClient client = new HttpClient();
            var CategoriesViewModel = new CategoriesViewModel();
            string response = await client.GetStringAsync(url);
            List<string> json = JsonConvert.DeserializeObject<List<string>>(response);
            CategoriesViewModel.Categories = new Categories();
            CategoriesViewModel.Categories.CategoriesList = json;
            if (category != null)
            {
                CategoriesViewModel.ChuckNorrisViewModel = await ChuckNorrisJokesRouting.GetJokePerCategory(category);
                return View("Categories", CategoriesViewModel);
            }
            else
            {
                return View("Categories", CategoriesViewModel);
            }
        }
    }
}
