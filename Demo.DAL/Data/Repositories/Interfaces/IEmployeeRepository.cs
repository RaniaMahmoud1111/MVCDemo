using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
   public interface IEmployeeRepository:IGenericRepository<Employee>
    {
       IQueryable<Employee> GetEmployeeByName(string name);// is related only for employee

    }
}
