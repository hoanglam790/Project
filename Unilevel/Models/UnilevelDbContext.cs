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

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<ChiTiet_Distributors> ChiTiet_Distributors { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Task_Details> Task_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasMany(e => e.ChiTiet_Distributors)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distributor>()
                .HasMany(e => e.ChiTiet_Distributors)
                .WithRequired(e => e.Distributor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Task_Details)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task_Details>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Task_Details>()
                .Property(e => e.Comment)
                .IsUnicode(false);
        }
    }
}
