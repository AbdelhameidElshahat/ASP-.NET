using LinkDev.IKEA.BLL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.IKEA.DAL.Presistance.Repositories.Employees;
using System.Net.Cache;
using LinkDev.IKEA.DAL.Common.Enums;
using LinkDev.IKEA.DAL.Entites.Employees;
using Microsoft.IdentityModel.Tokens;
namespace LinkDev.IKEA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) //Ask CLR for Creating Object from Class Implementing "IEmployeeRepository"
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<EmployeeDto> GetAllEmployees(string search)
        {

           var employees = _employeeRepository.GetAllAsIQueryable().Where(E=> !E.IsDeleted &&(string.IsNullOrEmpty(search)||E.Name.ToLower().Contains(search.ToUpper()))).Select(employee => new EmployeeDto()
           {
               Id = employee.Id,
               Name = employee.Name,
               Age = employee.Age,
               Address = employee.Address,
               IsActive = employee.IsActive,
               Email = employee.Email,
               Salary = employee.Salary,
               Departemtn =employee.Department.Name,
               Gender = employee.Gender.ToString(),
               EmployeeType = employee.EmployeeType.ToString(),
           }).ToList();
            return employees;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);

            if (employee is { })
            {
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    PhoneNumber = employee.PhoneNumber,
                    HiringDate = employee.HiringDate,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                };
            }
            return null;
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {

                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                DepartmentId = employeeDto.DepartmentId,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };

            return _employeeRepository.Add(employee);
        }
        public int UpdatEmployee(UpdateEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                DepartmentId = employeeDto.DepartmentId,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };

            return _employeeRepository.Update(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.Get(id);
            if(employee is { }) return _employeeRepository.Delete(employee) > 0;
            return false;
        }



    }
}
