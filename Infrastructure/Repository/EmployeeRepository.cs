using Domain;
using Domain.Repository;
using Persistence;
using Newtonsoft.Json;

namespace Infrastructure.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbContext dbContext;

    public EmployeeRepository(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public bool IsExistByNationalCode(string nationalCode)
    {
        var json = dbContext.ExecuteQuery($"SELECT * FROM Employees WHERE NationalCode='{nationalCode}';");
        return json != "[]";
    }

    public void Create(Employee employee)
    {
        dbContext.ExecuteCommand($"INSERT INTO Employees values" +
                                 $"('{employee.Id}', '{employee.FirstName}', '{employee.LastName}', '{employee.NationalCode}');");
    }

    public void Update(Employee employee)
    {
        dbContext.ExecuteCommand($"UPDATE Employees SET "+
                                 $"FirstName='{employee.FirstName}'," +
                                 $"LastName='{employee.LastName}'," +
                                 $"NationalCode='{employee.NationalCode}' " +
                                 $"WHERE Id='{employee.Id}'");
    }

    public void Delete(Employee employee)
    {
        dbContext.ExecuteCommand($"DELETE FROM Employees WHERE Id='{employee.Id}'");
    }

    public Employee GetById(Guid id)
    {
        var json = dbContext.ExecuteQuery($"SELECT * FROM Employees WHERE Id='{id}'");
        var employee = JsonConvert.DeserializeObject<List<EmployeeDatabaseModel>>(json)[0];
        employee.AddLeaves(GetEmployeeLeaves(employee.Id));
        return employee;
    }

    public void UpdateEmployeeLeaves(Employee employee)
    {
        dbContext.ExecuteCommand($"DELETE FROM Leaves WHERE EmployeeId='{employee.Id}'");
        string addLeavesCommand = $"INSERT INTO Leaves VALUES ";
        foreach (var employeeLeave in employee.Leaves)
        {
            addLeavesCommand += $"('{employeeLeave.Id}', '{employeeLeave.EmployeeId}', '{employeeLeave.FromDate}', '{employeeLeave.ToDate}'),";
        }
        dbContext.ExecuteCommand(addLeavesCommand.Remove(addLeavesCommand.Length - 1, 1));
    }

    public void AddEmployeeLeave(Leave leave)
    {
        dbContext.ExecuteCommand($"INSERT INTO Leaves VALUES " + 
                                 $"('{leave.Id}', '{leave.EmployeeId}', '{leave.FromDate}', '{leave.ToDate}');");
    }

    public IEnumerable<Employee> GetAll()
    {
        var json = dbContext.ExecuteQuery("SELECT * FROM Employees;");
        var employees = JsonConvert.DeserializeObject<List<EmployeeDatabaseModel>>(json);
        return employees;
    }

    private List<Leave> GetEmployeeLeaves(Guid employeeId)
    {
        var json = dbContext.ExecuteQuery($"SELECT * FROM Leaves WHERE EmployeeId='{employeeId}'");
        var employeeLeaves = JsonConvert.DeserializeObject<List<Leave>>(json);
        return employeeLeaves;
    }
}
