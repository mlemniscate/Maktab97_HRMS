﻿namespace Application.Dtos;

public class AddEmployeeLeaveDto
{
    public Guid EmployeeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}