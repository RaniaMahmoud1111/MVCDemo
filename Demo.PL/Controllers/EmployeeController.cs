using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController (IEmployeeService _employeeService):Controller
    {

        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();


            return View(Employees);
        }

    }
}
