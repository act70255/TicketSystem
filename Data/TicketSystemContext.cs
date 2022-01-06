using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public class TicketSystemContext : DbContext
    {
        public TicketSystemContext (DbContextOptions<TicketSystemContext> options)
            : base(options)
        {
        }

        public DbSet<TicketSystem.Models.Ticket> Ticket { get; set; }
        public DbSet<TicketSystem.Models.Account> Account { get; set; }
        public DbSet<TicketSystem.Models.Role> Role { get; set; }
        public DbSet<TicketSystem.Models.Premission> Premission { get; set; }
        public DbSet<TicketSystem.Models.AccountRole> AccountRole { get; set; }
        public DbSet<TicketSystem.Models.RolePremission> RolePremission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountRole>().HasOne(s => s.Account).WithMany(s => s.AccountRoles).HasForeignKey(s => s.AccountID);
            modelBuilder.Entity<AccountRole>().HasOne(s => s.Role).WithMany(s => s.AccountRoles).HasForeignKey(s => s.RoleID);
            modelBuilder.Entity<RolePremission>().HasOne(s => s.Role).WithMany(s => s.RolePremissions).HasForeignKey(s => s.RoleID);
            modelBuilder.Entity<RolePremission>().HasOne(s => s.Premission).WithMany(s => s.RolePremissions).HasForeignKey(s => s.PremissionID);
        }
    }
}
