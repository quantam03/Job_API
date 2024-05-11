using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeTitle { get; set; }
        public string? Description { get; set; }

        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }

        // Foreign key properties
        public int? DepartmentId { get; set; }
        public int? LocationId { get; set; }

        // Navigation properties
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; } // Navigation property for Department

        [ForeignKey("LocationId")]
        public Location? Location { get; set; } // Navigation property for Location
    }
}
