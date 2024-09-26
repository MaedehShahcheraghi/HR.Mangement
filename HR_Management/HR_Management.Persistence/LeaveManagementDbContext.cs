using HR_Management.Domain.Common;
using HR_Management_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Persistence
{
    public class LeaveManagementDbContext:DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options):base(options) 
        {
                
        }

        #region Entities
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if(entry.State != EntityState.Modified)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State != EntityState.Modified)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChanges();
        }
     
    }
}
