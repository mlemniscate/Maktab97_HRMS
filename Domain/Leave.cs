using Domain.Exception;

namespace Domain;

public class Leave
{
    public Leave(Guid employeeId, DateOnly fromDateTime, DateOnly toDateTime)
    {
        Id = Guid.NewGuid();
        EmployeeId = employeeId;
        SetDates(fromDateTime, toDateTime);
    }

    protected Leave() { }

    public Guid Id { get; }
    public Guid EmployeeId { get; private set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }

    private void SetDates(DateOnly fromDateTime, DateOnly toDateTime)
    {
        if (fromDateTime > ToDate)
            throw new FromDateBiggerThenToDateException();

        FromDate = fromDateTime;
        ToDate = toDateTime;
    }
}

public class HourlyLeave
{
    public TimeOnly LeaveTime { get; set; }
}