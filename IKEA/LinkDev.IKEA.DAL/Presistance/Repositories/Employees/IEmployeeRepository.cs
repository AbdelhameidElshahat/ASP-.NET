using LinkDev.IKEA.DAL.Entites.Employees;
using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.Presistance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Presistance.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
  
    }
}
