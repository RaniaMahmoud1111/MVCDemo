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
    // here i no long need that obj IEmployeeRepository _employeeRepository i use IunitOfWork which create IEmployeeRepository _employeeRepository in side it 
    public class EmployeeService(/*IEmployeeRepository _employeeRepository*/ IUnitOfWork _unitOfWork,IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking)
        {

            var Employees = _unitOfWork.EmployeeRepository.GetAll(withTracking);
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
        
        public IEnumerable<EmployeeDto> SearchEmployeeByName(string name)
        {

            var Employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name.ToLower());
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
            var Employee=_unitOfWork.EmployeeRepository.GetById(id);
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

        public int  CreateEmployee(CreatedEmployeeDto employee)
        {
            var Employee = _mapper.Map<CreatedEmployeeDto,Employee>(employee);

           /* return*/ _unitOfWork.EmployeeRepository.Add(Employee);
         return    _unitOfWork.SaveChanges();


        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
           /* return*/ _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employee));     
            return  _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee=_unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null) return false;
            else
            {
                employee.IsDeleted=true; 
                _unitOfWork.EmployeeRepository.Update(employee) ;
              return   _unitOfWork.SaveChanges()>0 ? true :false;
               
            }

           
        }



    }
}
