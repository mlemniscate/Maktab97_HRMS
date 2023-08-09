namespace Application.Dtos;

public class LeaveDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}