using Application.Dtos;

namespace Application;

public interface IEmployeeService
{
    void Create(EmployeeCreateDto employee);
    void AddLeave(AddEmployeeLeaveDto employeeLeaveDto);
    IEnumerable<EmployeeDto> GetAll();
    EmployeeDto GetById(Guid id);
}