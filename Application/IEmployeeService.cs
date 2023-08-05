using Application.Dtos;

namespace Application;

public interface IEmployeeService
{
    void Create(EmployeeCreateDto employee);
    IEnumerable<EmployeeDto> GetAll();
}