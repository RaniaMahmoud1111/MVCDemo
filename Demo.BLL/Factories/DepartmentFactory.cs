using Demo.BLL.DTO.DepartmentDtos;
using Demo.BLL.DTO.DepartmentDtos;
using Demo.DAL.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Factories
{
    // static class  that will has extension methods 
    public static  class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto()
            {
                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code=D.Code,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value),

            };

        }


        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value),
                Code = department.Code,
                CreatedBy= department.CreatedBy,
                LastModifiedBy= department.LastModifiedBy,


            };
        }


        public static Department ToEntity(this CreatedDepartmentDTO departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
            };
        }

        // method overloading (type, number ,order of paramters)
        public static Department ToEntity(this UpdateDepartmentDto departmentDto)
        {
            return new Department()
            {   Id=departmentDto.Id,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
            };

        }



    }
}
