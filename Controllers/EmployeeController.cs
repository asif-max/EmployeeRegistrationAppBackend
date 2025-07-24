using Microsoft.AspNetCore.Mvc;
using EmployeeRegistrationApp.DTOs;
using EmployeeRegistrationApp.Services;
using Microsoft.EntityFrameworkCore;
using EmployeeRegistrationApp.Enities;

namespace EmployeeRegistrationApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var result = await employeeService.GetAllEmployeesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(id);
        return employee is null
            ? NotFound($"Employee with ID {id} not found.")
            : Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto dto)
    {
        var exists = await employeeService.IfMobileExistAsync(dto.MobileNum);
        if (exists)
            return BadRequest("Mobile number already exists.");

        await employeeService.AddEmployeeAsync(dto);
        return Ok(new { message = "Employee added successfully." });

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto dto)
    {


        var updated = await employeeService.UpdateEmployeeAsync(dto);
        return updated == 0
            ? NotFound($"Employee with ID {dto.EmployeeId} not found.")
            : Ok( (new { message = "Employee added successfully." }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await employeeService.DeleteEmployeeAsync(id);
        return deleted == 0
            ? NotFound($"Employee with ID {id} not found.")
            : Ok((new { message = "Employee Deleted." }));
    }
    [HttpGet("countries")]
    public async Task<IActionResult> GetCountryName()
    {
        var countries = await employeeService.GetCountryName();
        return Ok(countries);
    }
    [HttpGet("states")]
    //public async Task<IActionResult> GetStatesList()
    //{
    //    var states = await employeeService.GetStatesList();
    //    return Ok(states);
    //}
    [HttpGet("{countryId}")]
    public async Task<IActionResult> GetStatesByCountryId(int countryId)
    {
        var states = await employeeService.GetStatesList(countryId);

        return Ok(states);
    }
}
