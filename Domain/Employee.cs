using Domain.Exception;
using Domain.Repository;

namespace Domain;

public class Employee
{
    private readonly IEmployeeRepository employeeRepository;
    protected List<Leave> leaves = new List<Leave>();

    public Employee(IEmployeeRepository employeeRepository,
        string? firstName, string? lastName, string? nationalCode)
    {
        this.employeeRepository = employeeRepository;
        SetName(firstName, lastName);
        SetNationalCode(nationalCode);
        Id = Guid.NewGuid();
    }

    protected Employee() {}

    public Guid Id { get; protected set; }

    public string FirstName { get; protected set; }

    public string LastName { get; protected set; }

    public string NationalCode { get; protected set; }

    public IReadOnlyList<Leave> Leaves => leaves.AsReadOnly();

    //
    // public List<HourlyLeave> HourlyLeaves { get; private set; } = new List<HourlyLeave>();

    public void AddLeave(Leave leave, IEmployeeRepository repository)
    {
        var leaveCount = Leaves.Sum(l => (l.FromDate.Date.DayOfYear - l.ToDate.Date.DayOfYear));
        if (leaveCount >= 26)
            throw new LeaveNotAllowedException();
    
        leaves.Add(leave);
        repository.AddEmployeeLeave(leave);
    }

    private void SetName(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new FirstNameIsRequiredException();
        LastName = lastName ?? throw new LastNameIsRequiredException();
    }

    private void SetNationalCode(string nationalCode)
    {
        if (employeeRepository.IsExistByNationalCode(nationalCode))
            throw new NationalCodeIsExistException();

        NationalCode = nationalCode;
    }
}
