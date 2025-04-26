using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models.EmployeeModel
{
    public class Employee:BaseEntity
    {
        public string Name { get; set;}
        public int Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set;}
        public string? PhoneNumber { get; set;}

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        //[ForeignKey("Department")]
        public  int? DepartmentId { get; set; }//fk
        // Navigation pro=> one 
        public virtual Department? Department { get; set; }// make virtual to applay lazy loading


    }
}
