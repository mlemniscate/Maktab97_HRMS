using Domain.Exception;

namespace Domain;

public class Leave
{
    public Leave(Guid employeeId, DateTime fromDateTime, DateTime toDateTime)
    {
        Id = Guid.NewGuid();
        EmployeeId = employeeId;
        SetDates(fromDateTime, toDateTime);
    }

    protected Leave() { }

    public Guid Id { get; }
    public Guid EmployeeId { get; private set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    private void SetDates(DateTime fromDateTime, DateTime toDateTime)
    {
        if (fromDateTime > toDateTime)
            throw new FromDateBiggerThenToDateException();

        FromDate = fromDateTime;
        ToDate = toDateTime;
    }
}

public class HourlyLeave
{
    public TimeOnly LeaveTime { get; set; }
}