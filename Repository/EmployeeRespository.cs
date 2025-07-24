using EmployeeRegistrationApp.Data;
using EmployeeRegistrationApp.Enities;

using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationApp.Repository
{
    public class EmployeeRespository(AppDbContext context) : IEmployeeRepository
    {
        // ✅ Add new employee with mobile number check
        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            var exists = await IfMobileExistAsync(employee.MobileNum);
            if (exists)
                throw new Exception("Mobile number already exists for another employee.");

            await context.Employees.AddAsync(employee);
            return await context.SaveChangesAsync();
        }

        // ✅ Returns true if mobile number already exists
        public async Task<bool> IfMobileExistAsync(string mobileNum)
        {
            return await context.Employees.AnyAsync(e => e.MobileNum == mobileNum);
        }

        // ✅ Delete by ID
        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
                return 0;

            context.Employees.Remove(employee);
            return await context.SaveChangesAsync();
        }

        // ✅ Get all employees
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await context.Employees.ToListAsync();
        }

        // ✅ Get all countries
        public async Task<List<Country>> GetCountryName()
        {
            return await context.Countries.ToListAsync();
        }

        // ✅ Get employee by ID
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await context.Employees.FindAsync(id);
        }

        // ✅ Get states by country ID
        public async Task<List<State>> GetStatesList(int countryId)
        {
            return await context.States
                .Where(s => s.CountryId == countryId)
                .ToListAsync();
        }

        // ✅ Update an employee with duplicate mobile check (excluding current employee)
        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            var existing = await context.Employees.FindAsync(employee.EmployeeId);
            if (existing == null)
                return 0;

            var isDuplicate = await context.Employees
                .AnyAsync(e => e.MobileNum == employee.MobileNum && e.EmployeeId != employee.EmployeeId);

            if (isDuplicate)
                throw new Exception("Mobile number already exists for another employee.");

            // Update fields
            existing.EmployeeName = employee.EmployeeName;
            existing.Age = employee.Age;
            existing.MobileNum = employee.MobileNum;
            existing.Pincode = employee.Pincode;
            existing.DOB = employee.DOB;
            existing.AddressLine1 = employee.AddressLine1;
            existing.AddressLine2 = employee.AddressLine2;
            existing.StateId = employee.StateId;
            existing.CountryId = employee.CountryId;

            return await context.SaveChangesAsync();
        }
    }
}
