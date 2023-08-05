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

    public IEnumerable<Employee> GetAll()
    {
        var json = dbContext.ExecuteQuery("SELECT * FROM Employees;");
        var employees = JsonConvert.DeserializeObject<List<EmployeeDatabaseModel>>(json);
        return employees;
    }
}
