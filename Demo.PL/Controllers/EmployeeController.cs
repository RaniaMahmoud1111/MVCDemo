using Demo.BLL.DTO.EmployeeDtos;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.PL.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Demo.PL.Controllers
{
    // service will call the repo
    // Performance issue happen by use IDepartmentService _departmentService in constractor as not all Action will need to use it so to solve it use it at Ation level not constructor 
    // are you see that you may use that ([FromServices]IDepartmentService _departmentService) in many actions and use ViewData to send that data to view so there is another good solution which you can inject the service in view directly 
    public class EmployeeController (IEmployeeService _employeeService, /*IDepartmentService _departmentService ,*/ ILogger<EmployeeController> _logger,IWebHostEnvironment _environment ):Controller
    {

        public IActionResult Index( string? EmployeeSearchName)
        {
           // TempData.Keep();// to save or transfer information through more than on action ex index => create =>edit 

            // Binding through view `s dictionary : transfer data from action to view 
            // we use  viewData,viewBag  to send information from Action => view , view =>Partial View , view => layout 
            //1. ViewData
            //if need good performance and type safty 
            // type detected by Compile Time 
            // Key always String 
            //   ViewData["Message"] = "Hello ViewData";

            //2.ViewBage 
            // if need dynamic type not matter what type it you depends on the CLR to detect 
            //   ViewBag.Message = "Hello ViewBage";

            //=============================================TempData==================================================

            // if need to send data between two requests (Actions or sequence of Actions)tempData.Keep to save it along with sequence of actions 

            dynamic Employees = null;
            if(string.IsNullOrEmpty(EmployeeSearchName))
            {
                Employees = _employeeService.GetAllEmployees();

            }
            else
            {
                Employees = _employeeService.SearchEmployeeByName(EmployeeSearchName);

            }

            return View(Employees);
        }

        #region Create Employee

        [HttpGet]
        public IActionResult Create(/*[FromServices]IDepartmentService _departmentService*/)
        {
           // ViewData["Departments"] = _departmentService.GetAllDepartments();// we also can use ViewBag but it with make error at run time for casting so we prefer ViewData
            return View();
        }
          

        [HttpPost]
        public IActionResult Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // manual mapping from EmployeeViewModel => CreatedEmployeeDTO
                    var employeeCreatedDto = new CreatedEmployeeDto()
                    {
                        Name=viewModel.Name,
                        Address=viewModel.Address,
                        Age=viewModel.Age,
                        IsActive=viewModel.IsActive,
                        Email=viewModel.Email,
                        EmployeeType=viewModel.EmployeeType,
                        Gender=viewModel.Gender,
                        HiringDate=viewModel.HiringDate,
                        PhoneNumber=viewModel.PhoneNumber,
                        Salary=viewModel.Salary,
                        DepartmentId=viewModel.DepartmentId,

                    };
                    int result = _employeeService.CreateEmployee(employeeCreatedDto);// nof rows affected 
                    if (result > 0)
                    {
                        TempData["Message"]="Employee Created Successfully";
                        return RedirectToAction(nameof(Index));//if employee created redirect to index view 
                    }
                    else
                    {
                        TempData["Message"] = "Employee Creation Failed ";
                        ModelState.AddModelError(string.Empty, "Employee can`t be created !!");
                        return RedirectToAction(nameof(Index));

                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }

            }
            //return bage of creation with same data user  entered it 
            return View(viewModel);
        }

        #endregion


        #region Show Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();//400
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null) return NotFound();//404

            return View(employee);


        }
        #endregion

        #region Edit Employee
        [HttpGet]
        public IActionResult Edit(int? id/*, [FromServices] IDepartmentService _departmentService*/)
        {
            if (!id.HasValue) return BadRequest();//400
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();//404
            // DetailsDto => UpdatedDto
            var UpdatedEmployee = new EmployeeViewModel()
            {
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Age = employee.Age,
                Salary = employee.Salary,
                Address = employee.Address,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                
            };
           // ViewData["Departments"] = _departmentService.GetAllDepartments();// we also can use ViewBag but it with make error at run time for casting so we prefer ViewData
            return View(UpdatedEmployee);

        }


        [ValidateAntiForgeryToken]// to prevent calling action from another tool like post man

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel viewModel)
        {
            try
            {
                // manual mapping 
                var employeeUpdatedDto = new UpdatedEmployeeDto()
                {
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    Age = viewModel.Age,
                    IsActive = viewModel.IsActive,
                    Email = viewModel.Email,
                    EmployeeType = viewModel.EmployeeType,
                    Gender = viewModel.Gender,
                    HiringDate = viewModel.HiringDate,
                    PhoneNumber = viewModel.PhoneNumber,
                    Salary = viewModel.Salary,

                };
                if (!ModelState.IsValid) return View(viewModel);

                int result = _employeeService.UpdateEmployee(employeeUpdatedDto);
                if (result > 0)//nof rows affected 
                {
                    TempData["Message"] = "Employee Updated Successfully!!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Employee Update Failed ";
                    ModelState.AddModelError(string.Empty, "Employee can`t be created !!");
                    return RedirectToAction(nameof(Index));
                }


            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ////1. Dev Env => log error in console and return same view with error msg
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    //2. Deployment => log error in file | table in db and return error view(include frindly error msg) not error msg
                    _logger.LogError(ex.Message);
                }
            }









            return View(viewModel);
        }

        #endregion

        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id )
        {
            try
            {
                if (id == 0) return NotFound();//means employee not  exist and 0 is the default value   

                bool deleted = _employeeService.DeleteEmployee(id);
                //here means employee exist 
                if (!deleted)
                    ModelState.AddModelError(string.Empty, "Employee can`t be deleted !");
            }
            catch (Exception ex)
            {

                if(_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
        
                return RedirectToAction(nameof(Index));


        }

        #endregion






    }
}
