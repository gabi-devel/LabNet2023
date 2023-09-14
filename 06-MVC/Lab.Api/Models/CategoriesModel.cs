using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Api.Models
{
    public class CategoriesModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}