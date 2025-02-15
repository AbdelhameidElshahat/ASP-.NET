﻿using LinkDev.IKEA.BLL.Models.Employees;
using LinkDev.IKEA.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();

        DepartmentDetailsDto? GetDepartmentById(int id);

        int CreateDepartment(CreatedDepartmentDto departmentDto);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);

    }
}
