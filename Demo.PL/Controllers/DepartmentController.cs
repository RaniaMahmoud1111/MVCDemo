using Demo.BLL.DTO;
using Demo.BLL.Services;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{//we not write any  bud=siness logic in controller or in repository so we make service to include all Blogic and the controller can call these services to use that logic
 //
 //base url => controller => service => repos   
 // senario of DI => obj of  department controller => obj of department service => obj of department repos => obj of dbcotext =>obj of dbcotext options(implicitly)
    public class DepartmentController(IDepartmentService _departmentService ,
        ILogger<DepartmentController> _logger ,IWebHostEnvironment _environment) : Controller
    {
        //  private readonly IDepartmentService _departmentService = departmentService;

        public IActionResult Index()//master page of controller 
        {
            var departments = _departmentService.GetAllDepartments();// here 

            return View(departments);

        }



        #region Department Create action 


        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO departmentDto )
        {
            //check data before deal with db

            if(ModelState.IsValid)// server side validation
            {
                try
                {
                    int result=_departmentService.AddDepartment(departmentDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can`t be created !!");
                    }
                }
                catch (Exception ex)
                {
                        // talk sql and happen exception
                        // log exec depends on env you are on 
                        //1. Dev Env => log error in console and return same view with error msg
                        //2. Deployment => log error in file | table in db and return error view(include frindly error msg) not error msg

                        // to check your env => inject obj from IWebHostEnv
                        // To log the error => inject obj from ILogger<DepartmentController>
               
                    if(_environment.IsDevelopment())
                        {
                            //1. Dev Env => log error in console and return same view with error msg
                            ModelState.AddModelError(string.Empty,ex.Message);
                        }
                    else
                        {
                            //2. Deployment => log error in file | table in db and return error view(include frindly error msg) not error msg

                            _logger.LogError(ex.Message);
                        }


                }

            }

            return View(departmentDto);
        }
        #endregion

        #region Details of Department

        //here we make Id Nullable and put condition on action route as if we make id not null and route not has id this means it another route to different action
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(!id.HasValue) return BadRequest(); // 400
            var department =_departmentService.GetDepartmentById(id.Value);
            if(department is null) return NotFound(); //404
            return View(department);


        }


        #endregion

        #region Edit Department


        [HttpGet]
        public IActionResult Edit(int ?id)
        {
            if(!id.HasValue)return BadRequest();//400
            var department = _departmentService.GetDepartmentById(id.Value);
            if(department is null) return NotFound();//404
          // mapping DepartmentDetailsDto to  DepartmentViewModel
            var departmentViewModel = new DepartmentViewModel()
            {
                Code=department.Code,
                Name=department.Name,
                Description=department.Description,
                DateOfCreation=department.CreatedOn


            };
            return View(departmentViewModel);
        }
        [ValidateAntiForgeryToken]// to prevent calling action from another toollike post man
        [HttpPost]
        //[FromRoute]int? id  this to prevent change it from insect in front 
        public IActionResult Edit([FromRoute]int? id,DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                // mapping DepartmentViewModel to  UpdateDepartment
                var updatedDepartment = new UpdateDepartmentDto()
                {
                    Id = id.Value,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DateOfCreation = viewModel.DateOfCreation
                };
                int result = _departmentService.UpdateDepartment(updatedDepartment);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department can`t be created !!");
                }


            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    //1. Dev Env => log error in console and return same view with error msg
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
    }
}
