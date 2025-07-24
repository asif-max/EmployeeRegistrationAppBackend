using EmployeeRegistrationApp.DTOs;
using EmployeeRegistrationApp.Enities;
using EmployeeRegistrationApp.Mapping;
using EmployeeRegistrationApp.Repository;

namespace EmployeeRegistrationApp.Services
{
    public class EmployeeService(IEmployeeRepository _repository,EmployeeMapper _mapper) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllEmployeesAsync();
            return employees.Select(emp => _mapper.MapToEmployeeResponseDto(emp)).ToList();
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            return employee is null ? null : _mapper.MapToEmployeeDto(employee);
        }

        public async Task<int> AddEmployeeAsync(EmployeeDto dto)
        {
            var employee = _mapper.MapToEmployee(dto);
            return await _repository.AddEmployeeAsync(employee);
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeDto dto)
        {
            var employee = _mapper.MapToEmployee(dto);
            return await _repository.UpdateEmployeeAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await _repository.DeleteEmployeeAsync(id);
        }

        public async Task<List<Country>> GetCountryName()
        {
            return await _repository.GetCountryName();
        }

        public async Task<List<State>> GetStatesList(int countryId)
        {
            return await _repository.GetStatesList(countryId);
        }

        public async Task<bool> IfMobileExistAsync(string mobileNum)
        {
            return await _repository.IfMobileExistAsync(mobileNum);
        }
    }
}

