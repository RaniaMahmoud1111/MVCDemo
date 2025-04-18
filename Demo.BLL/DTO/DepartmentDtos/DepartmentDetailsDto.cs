using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.DepartmentDtos
{
    public class DepartmentDetailsDto
    {
        // constructor mapping 
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Description = department.Description;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value);
        //}
        public int Id { get; set; }//pk
        public int CreatedBy { get; set; }// user id

        public DateOnly CreatedOn { get; set; }// Time of creation 

        public int LastModifiedBy { get; set; }//user id

        public bool IsDeleted { get; set; }// soft Delete 
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

    }
}
