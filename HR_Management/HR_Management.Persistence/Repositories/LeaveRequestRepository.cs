using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveRequestRepository(LeaveManagementDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _context.Entry(leaveRequest).State=EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            try
            {
               var leaveRequests= await _context.LeaveRequests.Include(t => t.LeaveType).ToListAsync();
                return leaveRequests;
            }
            catch (Exception)
            {

                throw ;
            }  
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            try
            {
                var leaveRequest = await _context.LeaveRequests.Include(t => t.LeaveType).FirstOrDefaultAsync(l=> l.Id==id);
                return leaveRequest;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
