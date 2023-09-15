using System.ComponentModel.DataAnnotations;

namespace Lab.MVC.Models
{
    public class CategoriesModel
    {
        public int? Id { get; set; }
        
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "La descripción admite un máximo de 200 caracteres.")] 
        public string Description { get; set; }
    }
}