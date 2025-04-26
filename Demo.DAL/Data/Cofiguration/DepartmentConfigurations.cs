using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Cofiguration
{
    internal class DepartmentConfigurations : BaseEntityConfigurations<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.Property(D=>D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.Name).HasColumnType("varchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");
            
            // here we write one Dept linked to many employees
            builder.HasMany(D=>D.Employees).WithOne(E=>E.Department).OnDelete(DeleteBehavior.Cascade);// by defualt one Employee linked to one dept so we not need to write it 

          
            base.Configure(builder);
        }

    }
}
