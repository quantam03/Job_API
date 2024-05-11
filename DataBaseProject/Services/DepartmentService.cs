using DataBaseProject.DatabaseContext;
using DataBaseProject.Interfaces;
using DataBaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProject.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly SqlServerContext _dBcontext;
        public DepartmentService(SqlServerContext dbcontext)
        {
            _dBcontext = dbcontext;
        }

        /// <summary>
        /// Get list of dept
        /// </summary>
        /// <returns></returns>
        public async Task<List<Department>> GetAllDepartment()
        {
            try
            {
                var department = await _dBcontext.Department.ToListAsync();


                return department;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        /// <summary>
        /// Get dept by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Department> GetDepartmentById(int id)
        {
            try
            {
                var department = await _dBcontext.Department
                    .FirstOrDefaultAsync(d => d.DepartmentId == id);

                return department;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        /// <summary>
        /// Create new dept
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<Department> CreateDepartment(Department department)
        {
            try
            {
                // Add the department to the DbSet
                _dBcontext.Department.Add(department);

                // Save changes to the database
                await _dBcontext.SaveChangesAsync();

                return department;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex ;
            }
        }

    }
}
