using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseProject.Models; 

namespace DataBaseProject.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeeData();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> AddUpdateEmployee(Employee employee);
    }
}
