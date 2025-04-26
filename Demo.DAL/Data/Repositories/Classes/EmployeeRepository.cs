using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    // here we not chain on base as base not have parameterless constructor 
    // here level of DI (ask clr to create obj) change from GenericRepository to EmployeeRepository
    //
    public class EmployeeRepository(AppDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        public IQueryable<Employee> GetEmployeeByName(string name)
        {
            return dbContext.Employees.Where(E => E.Name.ToLower().Contains(name));
        }
    }
}