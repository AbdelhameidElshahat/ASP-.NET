using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.Presistance.Data;
using LinkDev.IKEA.DAL.Presistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRepositry : GenericRepository<Department> , IDepartmentRepositry
    {
        public DepartmentRepositry(ApplicationDbContext dbContext) : base(dbContext) { } //Ask CLR for object from ApplicationDbcontext Implicitly

    }
}
