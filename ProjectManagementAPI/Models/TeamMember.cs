﻿namespace ProjectManagementAPI.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

    }
}
