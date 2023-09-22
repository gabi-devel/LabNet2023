using System.ComponentModel.DataAnnotations;

namespace Lab.MVC.Models
{
    public class EmployeesView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}