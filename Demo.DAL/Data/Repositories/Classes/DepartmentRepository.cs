using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region DI Senario 

/*
 
 i need to use Add method to add entity in db  
 notes 
1. that method is object member method means not static member method so you must create object to use it by that object .
2. Add method need to deal with dbset (table in db ) so we need to open connection with db and that done by create object from AppDbContext class which iherit from DbContext class 

that is easy lets make these 
if we create obj from AppDbContext by ownself this make a problem like:
* for each method we need to use connection we be opened with db that not good for security and for performance 
* not apply seperation of concern principle (as here in may class of DepartmentRepository i need to code only about that class i not need to write code related to another one )

so CLR with sovle these problem by Desgin Pattern Called DI (Dependency Injection)
Dependency : means i as a developer will depeneds on CLR on openning that connection with db by creating that object from AppDbContext
Injection: CLR will inject  to me the refernce of that object  and i will use that reference and iassegn it to the properity of AppDbContext that properity must be private and readonly 

so it not matter to me how that obj created but all problems solved

but there is another problem the developer may create parameter less constractor  and that will make another constractor with DI not used and 
  the properity of AppDbContext will assigned to null but that parameter less constractor so null reference execption will appear as i use that properity in my code 
to solve that problem we can use Primary Constructor (.net c#12 feature )that prevent creating parameter less constractor.

 * important step to use ID with specific service we must register that service in programm
 like this ( builder.Services.AddScoped<AppDbContext>();)
and spcify the lie time of object (
- Siglton : create one obj per project (not recommended in all cases but in some cases it good like (log exception , cashing ))
- Scoped : create one obj per request (it is bad in case of some requests not need to create obj from that service )
- Transient : create one obj per operation ()
)

The Dependency Injection pattern is a particular implementation of Inversion of Control. Inversion of Control (IoC) means that
objects do not create other objects on which they rely to do their work



          
 */

#endregion

namespace Demo.DAL.Data.Repositories.Classes
{
    // primary constructor .net 8 c#12 

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }


        // Controller =>BLL =>Repository =>db so not deal directly with db 
        public int Add(Department Entity)
        {
            _dbContext.Departments.Add(Entity);//added
          return  _dbContext.SaveChanges();//update db
        
        }

        public int Delete(Department Entity)
        {
            
           _dbContext.Departments.Remove(Entity);// remove locally  [status deleted]
            return _dbContext.SaveChanges();// applied in db
        }

        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            // get data withou tracking 
            if(withTracking)
            {
                return _dbContext.Departments.ToList();
            }

            return _dbContext.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {

            // pass id to find linq operator
            return _dbContext.Departments.Find(id);// if you have composite primary key you can send it as params
           // return _dbContext.Find<Department>(id);
        }

        public int Update(Department Entity)
        {
            _dbContext.Departments.Update(Entity);// update local[status modified ]

            return _dbContext.SaveChanges();// applied in db
        }

        


    }
}
