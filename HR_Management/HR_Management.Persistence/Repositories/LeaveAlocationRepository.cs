using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAlocationRepository:GenericRepository<LeaveAllocation>,ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveAlocationRepository(LeaveManagementDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            try
            {
                var leaveAllocations=await _context.LeaveAllocations.Include(t=> t.LeaveType).ToListAsync();
                return leaveAllocations;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            try
            {
                var leaveAllocation = await _context.LeaveAllocations.Include(t => t.LeaveType).FirstOrDefaultAsync(l=> l.Id==id);
                return leaveAllocation;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
