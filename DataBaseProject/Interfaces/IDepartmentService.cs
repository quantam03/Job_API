using DataBaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProject.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartment();

        Task<Department> GetDepartmentById(int id);

        Task<Department> CreateDepartment(Department department);
    }
}
