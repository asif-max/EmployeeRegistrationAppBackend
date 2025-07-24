using EmployeeRegistrationApp.DTOs;
using EmployeeRegistrationApp.Enities;

namespace EmployeeRegistrationApp.Mapping
{
    public class EmployeeMapper
    {
        // DTO to Entity
        public Employee MapToEmployee(EmployeeDto dto)
        {
            return new Employee
            {
                EmployeeId = dto.EmployeeId,
                EmployeeName = dto.EmployeeName,
                Age = dto.Age,
                MobileNum = dto.MobileNum,
                Pincode = dto.Pincode,
                DOB = dto.DOB,
                AddressLine1 = dto.AddressLine1,
                AddressLine2 = dto.AddressLine2,
                StateId = dto.StateId,
                CountryId = dto.CountryId
            };
        }

        // Entity to DTO
        public EmployeeDto MapToEmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Age = employee.Age,
                MobileNum = employee.MobileNum,
                Pincode = employee.Pincode,
                DOB = employee.DOB,
                AddressLine1 = employee.AddressLine1,
                AddressLine2 = employee.AddressLine2,
                StateId = employee.StateId,
                CountryId = employee.CountryId
            };
        }

        // Entity to Response DTO (for list/grid)
        public EmployeeResponseDto MapToEmployeeResponseDto(Employee employee)
        {
            return new EmployeeResponseDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Age = employee.Age,
                MobileNum = employee.MobileNum,
                Pincode = employee.Pincode,
                DOB = employee.DOB,
                AddressLine1 = employee.AddressLine1,
                AddressLine2 = employee.AddressLine2,
                StateId = employee.StateId,
                CountryId = employee.CountryId
            };
        }


    }
}
