using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
    // remember we dev against interface not against class 
    // Interface means :code Contract 
   public interface IDepartmentRepository
    {
        // signature for properity
        //1. get all (rt : list , array ... Icollection(if need to make operations,IEnumerable(prefered here) ,here we not need IQuerable as we not need to make filteration on result get all data  ) )
        // IEnumerable vs ReadOnlly
        // readOnly if we not need to iterat on data just read 
        //IEnumerable : can iterate on data but cannot make operations on it like (add , remove ), filteration done in my memory after data comes from db
        //IQuerable:filteration done db  
        //here we prefer IEnumerable 
        // in apis we prefer readonly as it return same i not need to iterat on it it return in json 
        // these tricks differ in performance 


        IEnumerable<Department> GetAll(bool withTracking=false);
        //2. get by id 

        Department GetById(int id);
        //3. update 

        // we make rt int as it return how many rows affected 
        int Update(Department Entity);
        //4. delete

        int Delete(Department Entity);
        //5. insert 

        int Add(Department Entity);


    }
}
