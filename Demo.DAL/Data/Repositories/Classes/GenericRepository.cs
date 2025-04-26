using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    //i not need save changes as i will applay unit of work and not make returntype of (add,update,delete)that represent nof rows affected in will make it void 
    public class GenericRepository<TEntity>(AppDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        // Controller =>BLL =>Repository =>db so not deal directly with db 
        public  void Add(TEntity Entity)
        {
           _dbContext.Set<TEntity>().Add(Entity);//added
           // _dbContext.Add(Entity);//here can detect typr of TEntity 
            //return _dbContext.SaveChanges();//update db  


        }

        public void Delete(TEntity Entity)
        {

            _dbContext.Set<TEntity>().Remove(Entity);// remove locally  [status deleted]
            //return _dbContext.SaveChanges();// applied in db
        }

        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            // get data withou tracking 
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(e=>e.IsDeleted==false).ToList();
            }

            return _dbContext.Set<TEntity>().Where(e=>e.IsDeleted==false).AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {

            // pass id to find linq operator
            return _dbContext.Set<TEntity>().Find(id);// if you have composite primary key you can send it as params
                                                   // return _dbContext.Find<TEntity>(id);
        }

        public void Update(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Update(Entity);// update local[status modified ]

            //return _dbContext.SaveChanges();// applied in db
        }

    }
}
