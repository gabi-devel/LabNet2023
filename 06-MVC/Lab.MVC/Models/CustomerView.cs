using System.ComponentModel.DataAnnotations;

namespace Lab.MVC.Models
{
    public class CustomerView
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        public string CompanyName { get; set; }
        
    }
}
