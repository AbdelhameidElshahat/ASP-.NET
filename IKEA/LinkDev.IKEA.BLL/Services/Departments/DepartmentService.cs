using LinkDev.IKEA.BLL.Models.Employees;
using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.Presistance.Repositories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepositry _departmentRepositry;

        public DepartmentService(IDepartmentRepositry departmentRepositry) //Ask CLR for Creating Class Implementing the Interface "IDepartmentRepositry"
        {
            _departmentRepositry = departmentRepositry;
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepositry.GetAllAsIQueryable().Where(D=> !D.IsDeleted).Select(deptartment => new DepartmentDto
            {
                Id = deptartment.Id,
                Code = deptartment.Code,
                Name = deptartment.Name,
                CreationDate = deptartment.CreationDate,
            }).AsNoTracking().ToList();
            return departments;
        }
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepositry.Get(id);
            if (department is not null)
            {
                return new DepartmentDetailsDto
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,
                };
            }
            return null;
        }
        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var Department = new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                //CreatedOn = DateTime.UtcNow,
                CreatedBy = 1,
                LastModifiedBy= 1,
                LastModifiedOn = DateTime.UtcNow,
            };
            return _departmentRepositry.Add(Department);
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var Department = new Department()
            {
                Id= departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };
            return _departmentRepositry.Update(Department);
        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepositry.Get(id);
            if(department is { })
            {
                return _departmentRepositry.Delete(department)>0;
            }
            return false;
        }

       
    }
}
