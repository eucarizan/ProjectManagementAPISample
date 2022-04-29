using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectManagementAPI.Models
{
    public partial class ProjectMgtContext : DbContext
    {
        public ProjectMgtContext()
        {
        }

        public ProjectMgtContext(DbContextOptions<ProjectMgtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<Assigned> Assigneds { get; set; } = null!;
        public virtual DbSet<ClientPartner> ClientPartners { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<OnProject> OnProjects { get; set; } = null!;
        public virtual DbSet<PrecedingActivity> PrecedingActivities { get; set; } = null!;
        public virtual DbSet<PrecedingTask> PrecedingTasks { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ProjectMgt;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("activity_name");

                entity.Property(e => e.ActualBudget)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("actual_budget");

                entity.Property(e => e.ActualEndTime)
                    .HasColumnType("date")
                    .HasColumnName("actual_end_time");

                entity.Property(e => e.ActualStartTime)
                    .HasColumnType("date")
                    .HasColumnName("actual_start_time");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.PlannedBudget)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("planned_budget");

                entity.Property(e => e.PlannedEndDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_end_date");

                entity.Property(e => e.PlannedStartDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_start_date");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<Assigned>(entity =>
            {
                entity.ToTable("assigned");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });

            modelBuilder.Entity<ClientPartner>(entity =>
            {
                entity.ToTable("client_partner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CpAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cp_address");

                entity.Property(e => e.CpDetails)
                    .HasColumnType("text")
                    .HasColumnName("cp_details");

                entity.Property(e => e.CpName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cp_name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("employee_code");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("employee_name");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");
            });

            modelBuilder.Entity<OnProject>(entity =>
            {
                entity.ToTable("on_project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientPartnerId).HasColumnName("client_partner_id");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("date_start");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IsClient).HasColumnName("is_client");

                entity.Property(e => e.IsPartner).HasColumnName("is_partner");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");
            });

            modelBuilder.Entity<PrecedingActivity>(entity =>
            {
                entity.ToTable("preceding_activity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.PrecedingActivityId).HasColumnName("preceding_activity_id");
            });

            modelBuilder.Entity<PrecedingTask>(entity =>
            {
                entity.ToTable("preceding_task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PrecedingTaskId).HasColumnName("preceding_task_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualEndDate)
                    .HasColumnType("date")
                    .HasColumnName("actual_end_date");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnType("date")
                    .HasColumnName("actual_start_date");

                entity.Property(e => e.PlannedEndDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_end_date");

                entity.Property(e => e.PlannedStartDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_start_date");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnType("text")
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<ProjectManager>(entity =>
            {
                entity.ToTable("project_manager");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualBudget)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("actual_budget");

                entity.Property(e => e.ActualEndTime)
                    .HasColumnType("date")
                    .HasColumnName("actual_end_time");

                entity.Property(e => e.ActualStartTime)
                    .HasColumnType("date")
                    .HasColumnName("actual_start_time");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.PlannedBudget)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("planned_budget");

                entity.Property(e => e.PlannedEndDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_end_date");

                entity.Property(e => e.PlannedStartDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_start_date");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("task_name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("team_name");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.ToTable("team_member");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("user_account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsProjectManager).HasColumnName("is_project_manager");

                entity.Property(e => e.LastName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RegistrationTime)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("registration_time");

                entity.Property(e => e.Username)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
