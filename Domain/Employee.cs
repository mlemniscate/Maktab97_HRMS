using Domain.Exception;
using Domain.Repository;

namespace Domain;

public class Employee
{
    private readonly IEmployeeRepository employeeRepository;

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

    // public List<Leave> Leaves { get; private set; } = new List<Leave>();
    //
    // public List<HourlyLeave> HourlyLeaves { get; private set; } = new List<HourlyLeave>();

    // public void AddLeave(Leave leave)
    // {
    //     var leaveCount = Leaves.Count + (HourlyLeaves.Sum(h => h.LeaveTime.Hour + h.LeaveTime.Minute) / 24);
    //     if (leaveCount >= 26)
    //         throw new System.Exception();
    //
    //     Leaves.Add(leave);
    // }

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
