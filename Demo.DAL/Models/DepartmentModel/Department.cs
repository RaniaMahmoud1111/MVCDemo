using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models.DepartmentModel
{
    public class Department : BaseEntity
    {
        // in .net5 ? nullable operator not exist the proerity is optional by default 
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        // Navigation pro =>many 
        public virtual ICollection <Employee> Employees { get; set; }=new HashSet<Employee>();//  assign by  HashSet  to make data unique ,make virtual to applay lazy loading


    }
}
