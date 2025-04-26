using Demo.DAL.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork/*,IDisposable*/
    {
        private Lazy<IEmployeeRepository> _EmployeeRepository ;

        private Lazy<IDepartmentRepository> _DepartmentRepository ;

        private readonly AppDbContext _dbContext ;

        // lazy implementation create obj when i need that is not Dependency Injection
        public UnitOfWork(/*IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository,*/ AppDbContext dbContext)
        {
            _EmployeeRepository = new Lazy<IEmployeeRepository>(()=>new EmployeeRepository(dbContext));
            _DepartmentRepository = new Lazy<IDepartmentRepository>(()=>new DepartmentRepository(dbContext));
            _dbContext = dbContext;
        }


        // this become not alway available 
        public IEmployeeRepository EmployeeRepository
        { get => _EmployeeRepository.Value; }
        public IDepartmentRepository DepartmentRepository
        { get => _DepartmentRepository.Value; }


        public int SaveChanges()// Commen name => Complete
        {
          return  _dbContext.SaveChanges();
        }



    //    public void Dispose()// this done implicitly by clr in dbcontext class
    //    {
    //        _dbContext.Dispose();
    //    }


    }
}
