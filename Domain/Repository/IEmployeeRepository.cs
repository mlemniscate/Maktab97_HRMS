namespace Domain.Repository;

public interface IEmployeeRepository
{   
    public bool IsExistByNationalCode(string nationalCode);
    void Create(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
    Employee GetById(Guid id);
    void UpdateEmployeeLeaves(Employee employee);
    void AddEmployeeLeave(Leave leave);
    IEnumerable<Employee> GetAll();
}