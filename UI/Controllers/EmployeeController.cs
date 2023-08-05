using System.Data;
using Application;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateDto employeeDto)
    {
        employeeService.Create(employeeDto);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<EmployeeDto>> GetAll()
    {
        var employeeDtos = employeeService.GetAll();
        return Ok(employeeDtos);
    }
}