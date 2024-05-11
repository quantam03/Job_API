using DataBaseProject.Interfaces;
using DataBaseProject.Models;
using DataBaseProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Job_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) // Corrected constructor method name
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployeeData")]
        public async Task<IActionResult> GetAllEmployeeData()
        {
            try
            {
                var response = await _employeeService.GetAllEmployeeData();

                if (response == null) return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var response = await _employeeService.GetEmployeeById(id);

                if (response == null) return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddUpdateEmployee")]
        public async Task<IActionResult> AddUpdateEmployee(Employee employee)
        {
            try
            {
                // Call the service method to create the department
                var response = await _employeeService.AddUpdateEmployee(employee);

                // Return the created department in the response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return BadRequest(ex.Message);
            }
        }
    }
}
