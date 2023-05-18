using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Unilevel.Models
{
    public partial class UnilevelDbContext : DbContext
    {
        public UnilevelDbContext()
            : base("name=UnilevelDbContext")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Area_Distributors> Area_Distributors { get; set; }
        public virtual DbSet<Area_Users> Area_Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Survey_Details> Survey_Details { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Task_Details> Task_Details { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasMany(e => e.Area_Users)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Area_Distributors)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Distributor>()
                .HasMany(e => e.Area_Distributors)
                .WithRequired(e => e.Distributor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distributor>()
                .HasMany(e => e.Plans)
                .WithRequired(e => e.Distributor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey_Details>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<Survey_Details>()
                .Property(e => e.A)
                .IsUnicode(false);

            modelBuilder.Entity<Survey_Details>()
                .Property(e => e.B)
                .IsUnicode(false);

            modelBuilder.Entity<Survey_Details>()
                .Property(e => e.C)
                .IsUnicode(false);

            modelBuilder.Entity<Survey_Details>()
                .Property(e => e.D)
                .IsUnicode(false);

            modelBuilder.Entity<Survey_Details>()
                .Property(e => e.Result)
                .IsFixedLength();

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Task_Details>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Time>()
                .HasMany(e => e.Plans)
                .WithRequired(e => e.Time)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Area_Users)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
