using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CategoriesMVCController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {

            return View();
        }
    }
    //public async Task<List<EmployeeDto>> GetAllAsync()
    //{
    //    return await _dbContext.Employees
    //        .Select(e => MapToDto(e))
    //        .ToListAsync();
    //}

    //public async Task CreateAsync(EmployeeDto employeeDto)
    //{
    //    var employee = MapToEntity(employeeDto);
    //    _dbContext.Employees.Add(employee);
    //    await _dbContext.SaveChangesAsync();
    //}

}