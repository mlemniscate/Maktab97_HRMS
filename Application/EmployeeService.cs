using Application.Dtos;
using AutoMapper;
using Domain;
using Domain.Repository;

namespace Application;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IMapper mapper;

    public EmployeeService(IEmployeeRepository employeeRepository,
        IMapper mapper)
    {
        this.employeeRepository = employeeRepository;
        this.mapper = mapper;
    }

    public void Create(EmployeeCreateDto employeeDto)
    {
        var employee = new Employee(employeeRepository,
            employeeDto.FirstName,
            employeeDto.LastName,
            employeeDto.NationalCode);

        employeeRepository.Create(employee);
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        var employees = employeeRepository.GetAll();
        return mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
}