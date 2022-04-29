using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class OnProject
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? ClientPartnerId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsClient { get; set; }
        public bool? IsPartner { get; set; }
        public string? Description { get; set; }
    }
}
