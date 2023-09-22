using System.ComponentModel.DataAnnotations;

namespace Lab.MVC.Models
{
    public class CategoriesApiModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}