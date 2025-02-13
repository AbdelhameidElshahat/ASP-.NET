using LinkDev.IKEA.BLL.Models.Employees;
using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.BLL.Services.Employees;
using LinkDev.IKEA.DAL.Entites.Employees;
using LinkDev.IKEA.PL.ViewModels.Departments;
using LinkDev.IKEA.PL.ViewModels.Employess;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LinkDev.IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<Employee> _logger;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService ,IWebHostEnvironment webHostEnvironment , ILogger<Employee> logger ,IDepartmentService departmentService )
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _departmentService = departmentService;
        }

        #region Index
        [HttpGet] // Get /Employee / Index
        public IActionResult Index(string search)
        {
            var employees = _employeeService.GetAllEmployees(search);

            return View(employees);
        }
        #endregion

        #region Details
        [HttpGet] // Employee/Details/id
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee is null) return NotFound();

            return View(employee);
        }
        #endregion

        #region Create
        [HttpGet] //Get/Department/Create
        public IActionResult Create()
        {
            ViewData["Departments"] =_departmentService.GetAllDepartments();
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost] //Post 
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return View(employeeDto);
            var message = string.Empty;
            try
            {
                var Updated = _employeeService.CreateEmployee(employeeDto);
                if (Updated > 0)
                    return RedirectToAction("Index");
                else
                {
                    message = "Department Is Not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(Updated);
                }
            }
            catch (Exception ex)
            {
                //1.Log Exception
                _logger.LogError(ex, ex.Message);
                //2.Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An Error has Ocured During Creating The Department :(";


            }
            ModelState.AddModelError(string.Empty, message);
            return View(employeeDto);

        }

        #endregion

        #region Update
        [HttpGet] //Get /Department / Edit/id?
        public IActionResult Edit(int? id)
        {
            ViewData["Departments"] = _departmentService.GetAllDepartments();
            if (id is null) return BadRequest(); //400
            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null) return NotFound(); // 404

            return View(new EmployeeEditViewModel()
            {
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender
            });
        } //Server Side Validation
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, EmployeeEditViewModel employeeEditViewModel)
        {
            var message = string.Empty;
            if (!ModelState.IsValid) return View(employeeEditViewModel);

            try
            {
                var employeeToUpdate = new UpdateEmployeeDto()
                {
                    Id = id,
                    Name = employeeEditViewModel.Name,
                    Address = employeeEditViewModel.Address,
                    Age = employeeEditViewModel.Age,
                    Email = employeeEditViewModel.Email,
                    Salary = employeeEditViewModel.Salary,
                    PhoneNumber = employeeEditViewModel.PhoneNumber,
                    HiringDate = employeeEditViewModel.HiringDate,
                    IsActive = employeeEditViewModel.IsActive,
                    EmployeeType = employeeEditViewModel.EmployeeType,
                    Gender = employeeEditViewModel.Gender
                };
                var updated = _employeeService.UpdatEmployee(employeeToUpdate) > 0;

                if (updated) return RedirectToAction("Index");
                message = "An Error has Ocured During Updating The Department :(";
            }
            catch (Exception ex)
            {
                //1.Log Exception
                _logger.LogError(ex, ex.Message);
                //2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An Error has Ocured During Updating The Department :(";

            }
            ModelState.AddModelError(string.Empty, message);
            return View(employeeEditViewModel);
        }
        #endregion

        #region Delete
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var deleted = _employeeService.DeleteEmployee(id);

                if (deleted) return RedirectToAction(nameof(Index));

                message = "an error has occured during Deleting the department :(";
            }
            catch (Exception ex)
            {

                //1.Log Exception
                _logger.LogError(ex, ex.Message);
                //2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An Error has Ocured During Deleting The Department :(";

            }
            ModelState.AddModelError(string.Empty, message);
            return View(nameof(Index));
        }
        #endregion


    }
}



