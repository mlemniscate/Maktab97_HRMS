namespace Application.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NationalCode { get; set; }

    public List<LeaveDto> Leaves { get; set; }
}