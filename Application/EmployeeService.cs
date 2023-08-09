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

    public void AddLeave(AddEmployeeLeaveDto employeeLeaveDto)
    {
        var employee = employeeRepository.GetById(employeeLeaveDto.EmployeeId);
        employee.AddLeave(new Leave(employeeLeaveDto.EmployeeId, employeeLeaveDto.FromDate, employeeLeaveDto.ToDate),
            employeeRepository);
        // employeeRepository.UpdateEmployeeLeaves(employee);
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        var employees = employeeRepository.GetAll();
        return mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public EmployeeDto GetById(Guid id)
    {
        var emlployee = employeeRepository.GetById(id);
        return mapper.Map<EmployeeDto>(emlployee);
    }
}