using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
    // Generic repo as we have more than one entity
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity // ensure class which inherit that interface must be domain model 
    {
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        //2. get by id 

        TEntity GetById(int id);
        //3. update 

        // we make rt int as it return how many rows affected 
        int Update(TEntity Entity);
        //4. delete

        int Delete(TEntity Entity);
        //5. insert 

        int Add(TEntity Entity);
    }
}
