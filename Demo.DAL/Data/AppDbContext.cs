using Demo.DAL.Data.Cofiguration;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        // with executed by dbcontext options implicitly OnModelCreating with my cs
         
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // to enable your request to run maltiple query use that attribbue (MultieActiveResultSet=true)
        //    optionsBuilder.UseSqlServer("Server=;Database=MVC_C43;Trusted_Connection=true");

        //}
        // if i make any fluent api run it in OModelCreating()

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // not need  to run  OModelCreating() of base (that run  fluent api related to entities in  dbcontext)
            // i need to run fluent apis of entities 
            // in security module we will implement IdentityDbContext so that we will need to applay OnModelCreating of base in that case

            // apply configurations of my entities 
           // modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());// 
            // if we have many entities need to apply its configurations use easy way () 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());// existing in same project = same assembly
                                                                                          // apply all configuration on that assembly 

        }
       public DbSet<Department> Departments { get; set; }//table 
       public DbSet<Employee> Employees { get; set; }//table 
    }
}
