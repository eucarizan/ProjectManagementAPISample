using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class ClientPartner
    {
        public int Id { get; set; }
        public string? CpName { get; set; }
        public string? CpAddress { get; set; }
        public string? CpDetails { get; set; }
    }
}
