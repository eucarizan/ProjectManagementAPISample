using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class PrecedingActivity
    {
        public int Id { get; set; }
        public int? ActivityId { get; set; }
        public int? PrecedingActivityId { get; set; }
    }
}
