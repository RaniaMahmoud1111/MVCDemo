using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
   public interface IUnitOfWork
    {
        // repo for each table or dbset in dbcontext
        public IEmployeeRepository EmployeeRepository { get;  }
        public IDepartmentRepository DepartmentRepository  { get;  }

        int SaveChanges();
        // also can make signature for Displose but it called implicitly by DbContext

    }
}
