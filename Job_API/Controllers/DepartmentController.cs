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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) // Corrected constructor method name
        {
            _departmentService = departmentService;
        }



        /// <summary>
        /// Get All departments
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var response = await _departmentService.GetAllDepartment();

                if (response == null) return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


     /// <summary>
     /// Get Department by ID
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
        [HttpPut("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var response = await _departmentService.GetDepartmentById(id);

                if (response == null) return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New dept
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            try
            {
                // Call the service method to create the department
                var addDepartment = await _departmentService.CreateDepartment(department);

                // Return the created department in the response
                return Ok(addDepartment);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return BadRequest(ex.Message);
            }
        }
    }
}
