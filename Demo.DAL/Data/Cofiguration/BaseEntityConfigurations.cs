using Demo.DAL.Models;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Cofiguration
{
    // here we make base Configurations that hold the comment configurations
    // here we make that class generic of type must be  BaseEntity class or any class inherit from  BaseEntity
    // so we applay seperation of concern and avoid repetations 

    public class BaseEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");// for insert only and not changes  
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()"); //calc each run (for each update ), This will set LastModifiedOn to the current timestamp on update


        }
    }
}
