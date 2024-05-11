using DataBaseProject.Interfaces;
using DataBaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseProject.DatabaseContext;
using Microsoft.EntityFrameworkCore;



namespace DataBaseProject.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly SqlServerContext _dBcontext;
        public EmployeeServices(SqlServerContext dbcontext)
        {
            _dBcontext = dbcontext;
        }

        public async Task<List<Employee>> GetAllEmployeeData()
        {
            try
            {
                var employeeData = await _dBcontext.Employee
                    .Include(e => e.Department)
                    .Include(e => e.Location)
                    .ToListAsync();

                return employeeData;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _dBcontext.Employee
                    .Include(e => e.Department)
                    .Include(e => e.Location)
                    .FirstOrDefaultAsync(e => e.EmployeeId == id);

                return employee;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        public async Task<Employee> AddUpdateEmployee(Employee employee)
        {
            try
            {
                // Employee ID is 0, indicating it's a new employee, so add it to the context
                _dBcontext.Employee.Add(employee);


                // Save changes to the database
                await _dBcontext.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }



    }
}
