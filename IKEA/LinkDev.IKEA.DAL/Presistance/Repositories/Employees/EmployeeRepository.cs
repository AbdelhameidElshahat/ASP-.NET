using LinkDev.IKEA.DAL.Entites.Employees;
using LinkDev.IKEA.DAL.Presistance.Data;
using LinkDev.IKEA.DAL.Presistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Presistance.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) :base(dbContext) { } //Ask CLR for object from ApplicationDbcontext Implicitly

    }
}
