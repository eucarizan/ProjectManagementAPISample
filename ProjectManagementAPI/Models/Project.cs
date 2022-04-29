using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string? ProjectDescription { get; set; }
    }
}
