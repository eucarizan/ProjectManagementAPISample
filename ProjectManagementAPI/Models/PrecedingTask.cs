using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class PrecedingTask
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? PrecedingTaskId { get; set; }
    }
}
