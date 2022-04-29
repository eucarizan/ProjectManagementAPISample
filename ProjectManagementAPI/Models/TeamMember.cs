using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class TeamMember
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoleId { get; set; }
    }
}
