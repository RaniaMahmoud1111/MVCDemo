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
    internal class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {// here which Configure method need to apply of base or of child
        // we need to apply configur of child so we use (new) key word to make new version of configure than of base 
        // also we need to apply configure of base so we use base.Configure(builder);

        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");

            // enum  we need to deal with it as enum in app but in db as string 
            builder.Property(E => E.Gender).HasConversion((empGender) => empGender.ToString(),
                (returendEmpGender) => (Gender)Enum.Parse(typeof(Gender), returendEmpGender));

            builder.Property(E => E.EmployeeType).HasConversion((empType) => empType.ToString(),
                (returnedEmpType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), returnedEmpType));

            base.Configure(builder);
        }
    }
}
