using LinkDev.IKEA.BLL.Models.Employees;
using LinkDev.IKEA.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using LinkDev.IKEA.PL.ViewModels.Departments;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LinkDev.IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
       #region Services
        //DepartmentController is a Controller 
        //DepartmentController has a _departmentService
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _enviroment;

        public DepartmentController(IDepartmentService departmentService,
            ILogger<DepartmentController> logger,
            IWebHostEnvironment enviroment)
        {

            _logger = logger;
            _enviroment = enviroment;
            _departmentService = departmentService;
        }
        #endregion

        #region Index
        [HttpGet] // Get /employee / Index
        public IActionResult Index()
        {
            var Departments = _departmentService.GetAllDepartments();

            return View(Departments);
        }
        #endregion

        #region Details
        [HttpGet] // Department/Details/id
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null) return NotFound();

            return View(department);
        }
        #endregion

        #region Create
        [HttpGet] //Get/Department/Create
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost] //Post 
        public IActionResult Create(CreatedDepartmentDto department)
        {
            if (!ModelState.IsValid)
                return View(department);
            var message = string.Empty;
            try
            {

                var Created = _departmentService.CreateDepartment(department);
                
                if (Created > 0)
                {
                    TempData["Message"] = "Department Is Created";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Department Is Not Created";
                    message = "Department Is Not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(Created);
                }
            }
            catch (Exception ex)
            {
                //1.Log Exception
                _logger.LogError(ex, ex.Message);
                //2.Set Message
                message = _enviroment.IsDevelopment() ? ex.Message : "An Error has Ocured During Creating The Department :(";


            }
            ModelState.AddModelError(string.Empty, message);
            return View(department);

        }

        #endregion

        #region Update
        [HttpGet] //Get /Department / Edit/id?
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest(); //400
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department == null) return NotFound(); // 404

            return View(new DepartmentEditViewModel()
            {
                //id = id.Value,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
            });
        } //Server Side Validation
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel departmentEditVM)
        {
            var message = string.Empty;
            if (!ModelState.IsValid) return View(departmentEditVM);

            try
            {
                var departmentToUpdate = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = departmentEditVM.Code,
                    Name = departmentEditVM.Name,
                    Description = departmentEditVM.Description,
                    CreationDate = departmentEditVM.CreationDate,
                };
                var updated = _departmentService.UpdateDepartment(departmentToUpdate) > 0;

                if (updated) return RedirectToAction("Index");
                message = "An Error has Ocured During Updating The Department :(";
            }
            catch (Exception ex)
            {
                //1.Log Exception
                _logger.LogError(ex, ex.Message);
                //2. Set Message
                message = _enviroment.IsDevelopment() ? ex.Message : "An Error has Ocured During Updating The Department :(";

            }
            ModelState.AddModelError(string.Empty, message);
            return View(departmentEditVM);
        }
        #endregion

        #region Delete
        [ValidateAntiForgeryToken]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();

            var departemnt = _departmentService.GetDepartmentById(id.Value);

            if (departemnt is null) return NotFound();

            return View(departemnt);


        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var deleted = _departmentService.DeleteDepartment(id);

                if (deleted) return RedirectToAction(nameof(Index));

                message = "an error has occured during Deleting the department :(";
            }
            catch (Exception ex)
            {

                //1.Log Exception
                _logger.LogError(ex, ex.Message);
                //2. Set Message
                message = _enviroment.IsDevelopment() ? ex.Message : "An Error has Ocured During Deleting The Department :(";

            }
            ModelState.AddModelError(string.Empty, message);
            return View(nameof(Index));
        } 
        #endregion


    }
}

