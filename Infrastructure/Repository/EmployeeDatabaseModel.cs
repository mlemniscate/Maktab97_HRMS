using Domain;

namespace Infrastructure.Repository;

public class EmployeeDatabaseModel : Employee
{
    public EmployeeDatabaseModel(Guid id, string firstName, string lastName, string nationalCode)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
    }
    
    public void AddLeaves(List<Leave> leaves)
    {
        base.leaves = leaves;
    }
}