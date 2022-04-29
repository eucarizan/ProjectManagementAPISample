using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public int? ProjectId { get; set; }
        public int? Priority { get; set; }
        public string? Description { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public decimal? PlannedBudget { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public decimal? ActualBudget { get; set; }
    }
}
