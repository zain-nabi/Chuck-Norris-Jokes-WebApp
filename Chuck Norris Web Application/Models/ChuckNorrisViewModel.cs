using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chuck_Norris_Web_Application.Models
{
    public class ChuckNorrisViewModel
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string updated_at { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class CategoriesViewModel
    {
        public ChuckNorrisViewModel ChuckNorrisViewModel { get; set; }
        public Categories Categories { get; set; }
    }

    public class Categories
    {
        public List<string> CategoriesList { get; set; }
    }
}
