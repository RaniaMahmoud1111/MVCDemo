using Demo.BLL.DTO.DepartmentDtos;
using Demo.BLL.DTO.DepartmentDtos;
using Demo.BLL.Factories;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Classes
{
    // primary constructor .net 8 feature  to avoid parameterless creating constructor 
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        // private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        // types of mapping 
        //1.manual mapping // bad in readability  for small project 
        //2. auto mapper// common use 
        //3. constructor mapping // bad in readability 
        //4. extension method // common use  

        // on folder click ctrl shift A => to create obj 


        //  Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()  //here okay
        {
            // use obj member method GettAll() that exist in Dept Repo  so we need to apply DI

            var departments = _departmentRepository.GetAll();
            //1. manual mapping 
            //    var departmentsToReturn = departments.Select(D => new DepartmentDTO()
            //    {
            //        Id = D.Id,
            //        Name = D.Name,
            //        Description = D.Description,
            //        DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            //    });
            //     return departmentsToReturn;

            // 2.extension method 
            return departments.Select(D => D.ToDepartmentDto());
        }



        //  Get  Department by id 
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            //1. manual mapping
            //if (department == null) return null;
            //else
            //{
            //    var departmentToReturn = new DepartmentDetailsDto()
            //    {
            //        Id= department.Id,
            //        Name = department.Name,
            //        Description = department.Description,
            //        Code = department.Code,
            //        CreatedOn= DateOnly.FromDateTime(department.CreatedOn.Value)

            //    };
            //    return departmentToReturn;
            //}

            //2. constructor mapping   using ternary operator 
            //  return department is null ?null: new DepartmentDetailsDto(department)
            // {
            //    Id = department.Id,
            //    Name = department.Name,
            //    Description = department.Description,
            //    Code = department.Code,
            //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value)

            //   };

            // 2.extension method 
            return department is null ? null : department.ToDepartmentDetailsDto();// here ToDepartmentDetailsDto() will take its parameters from caller  (department)

        }

        // Add Department
        public int AddDepartment(CreatedDepartmentDTO departmentDto)//its return int means how many row affected
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);
        }

        // Update Department
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }


        // Delete Department

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int result = _departmentRepository.Delete(department);
                return result > 0 ? true : false;
            }

        }
    }
}
