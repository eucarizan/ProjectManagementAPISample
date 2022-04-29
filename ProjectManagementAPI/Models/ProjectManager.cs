using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class ProjectManager
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? UserAccountId { get; set; }
    }
}
