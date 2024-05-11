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


        /// <summary>
        /// To get all employee Data
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// To get employee data for a particular ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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



        /// <summary>
        /// To add new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                // Call the service method to create the department
                var response = await _employeeService.AddEmployee(employee);

                // Return the created department in the response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To delete employee data for a particular ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                // Call the service method to delete the employee
                var response = await _employeeService.DeleteEmployee(id);

                if (response == true)
                {
                    // If deletion was successful, return Ok response
                    return Ok(response);
                }
                else
                {
                    // If employee was not found or deletion failed, return NotFound
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately and return BadRequest
                return BadRequest(ex.Message);
            }
        }


    }
}
