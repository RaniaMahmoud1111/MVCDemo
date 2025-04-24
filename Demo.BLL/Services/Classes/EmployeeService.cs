using AutoMapper;
using Demo.BLL.DTO.EmployeeDtos;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositories.Classes;
using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Classes
{
    // check if you register service  in program to work with DI 
    public class EmployeeService(IEmployeeRepository _employeeRepository,IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking)
        {

            var Employees = _employeeRepository.GetAll(withTracking);
            // src=IEnumerable<Employee>
            // Dest=IEnumerable<EmployeeDto>
            var returnedEmployees=_mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>> (Employees);//auto mapping

            // manual mapping 
            //var returnedEmployees = Employees.Select(emp => new EmployeeDto()
            //{
            //    Id=emp.Id,
            //    Name=emp.Name,
            //    Age=emp.Age,
            //    Email=emp.Email,
            //    Salary=emp.Salary,
            //    IsActive=emp.IsActive,
            //    EmployeeType=emp.EmployeeType.ToString(),
            //    Gender=emp.Gender.ToString(),
            //});
            return returnedEmployees;


        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var Employee=_employeeRepository.GetById(id);
            //if (Employee == null) return null;
            //return new EmployeeDetailsDto()
            //{
            //    Id = Employee.Id,
            //    Name = Employee.Name,
            //    Age = Employee.Age,
            //    Email = Employee.Email,
            //    Salary = Employee.Salary,
            //    IsActive = Employee.IsActive,
            //    EmployeeType = Employee.EmployeeType.ToString(),
            //    Gender = Employee.Gender.ToString(),
            //    PhoneNumber = Employee.PhoneNumber,
            //    HiringDate = DateOnly.FromDateTime(Employee.HiringDate),
            //    CreatedBy=1,
            //    LastModifiedBy=1,
            //};

            return Employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(Employee);

        }

        public int CreateEmployee(CreatedEmployeeDto employee)
        {
            var Employee = _mapper.Map<CreatedEmployeeDto,Employee>(employee);

            return _employeeRepository.Add(Employee);

        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employee));     
        }

        public bool DeleteEmployee(int id)
        {
            var employee=_employeeRepository.GetById(id);
            if (employee == null) return false;
            else
            {
                employee.IsDeleted=true; 
                return _employeeRepository.Update(employee) >0 ? true: false ;
            }

           
        }



    }
}
