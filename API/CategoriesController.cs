using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class CategoriesController
    {
        public CategoriesController()
        {
        }
        //initial db has these 3 values
        public static void InitDatabase()
        {
            CategoriesService.Create("Beverages");
            CategoriesService.Create("Condiments");
            CategoriesService.Create("Confections");
        }
    }
}
