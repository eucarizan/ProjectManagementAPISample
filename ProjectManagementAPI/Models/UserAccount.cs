using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsProjectManager { get; set; }
        public byte[] RegistrationTime { get; set; } = null!;
    }
}
