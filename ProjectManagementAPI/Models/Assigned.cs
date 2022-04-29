using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class Assigned
    {
        public int Id { get; set; }
        public int? ActivityId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoleId { get; set; }
    }
}
