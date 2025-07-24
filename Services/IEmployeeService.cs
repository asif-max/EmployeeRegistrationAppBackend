using EmployeeRegistrationApp.DTOs;
using EmployeeRegistrationApp.Enities;
using EmployeeRegistrationApp.Repository;

namespace EmployeeRegistrationApp.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(EmployeeDto dto);
        Task<int> UpdateEmployeeAsync(EmployeeDto dto);
        Task<int> DeleteEmployeeAsync(int id);
        Task<List<Country>> GetCountryName();
        Task<List<State>> GetStatesList(int countryId);
        Task<bool> IfMobileExistAsync(string mobileNum);
    }
}
