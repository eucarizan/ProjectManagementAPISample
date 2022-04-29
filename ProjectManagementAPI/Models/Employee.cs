using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public int? UserAccountId { get; set; }
    }
}
