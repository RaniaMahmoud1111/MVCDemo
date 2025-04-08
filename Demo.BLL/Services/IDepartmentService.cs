using Demo.BLL.DTO;

namespace Demo.BLL.Services
{
    public interface IDepartmentService//code contract 
    {
        int AddDepartment(CreatedDepartmentDTO departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}