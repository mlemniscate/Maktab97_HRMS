namespace Application.Dtos;

public class AddEmployeeLeaveDto
{
    public Guid EmployeeId { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
}