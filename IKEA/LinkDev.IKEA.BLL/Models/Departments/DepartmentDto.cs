﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employees
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        //public int CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public int LastModifiedBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }


        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
       
        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; } //Time that this department is created in company 
    }
}
