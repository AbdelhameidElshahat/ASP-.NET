using LinkDev.IKEA.DAL.Common.Enums;
using LinkDev.IKEA.DAL.Entities;
using LinkDev.IKEA.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Entites.Employees
{
    public class Employee :ModelBase
    {
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        //[RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address Must Be like 123-Street-City-Country")]
        public string? Address { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        //Forigen Key
        public int? DepartmentId { get; set; }
        //Navigational Property [One]
        public virtual Department? Department { get; set; }


    }
}
