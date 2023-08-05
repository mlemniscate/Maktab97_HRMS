namespace Domain;

public class Leave
{
    public Leave(Guid employeeId, DateTime fromDateTime, DateTime toDateTime)
    {
        Id = Guid.NewGuid();
        EmployeeId = employeeId;
        FromDateTime = fromDateTime;
        ToDateTime = toDateTime;
    }

    protected Leave() { }

    public Guid Id { get; }
    public Guid EmployeeId { get; private set; }
    public DateTime FromDateTime { get; set; }
    public DateTime ToDateTime { get; set; }
}

public class HourlyLeave
{
    public TimeOnly LeaveTime { get; set; }
}