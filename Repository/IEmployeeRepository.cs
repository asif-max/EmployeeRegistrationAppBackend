using EmployeeRegistrationApp.Enities;

namespace EmployeeRegistrationApp.Repository
{
    public interface IEmployeeRepository
    {
       
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(int id);
        Task<List<Country>> GetCountryName();
        Task<List<State>> GetStatesList(int countryId);
        Task<bool> IfMobileExistAsync(string mobileNum);

    }
}
