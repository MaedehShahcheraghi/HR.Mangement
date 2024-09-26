using HR_Management.MVC.Models.LeaaveRequestModels;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestVM>> GetLeaveRequestAsync();
        Task<UpdateLeaveRequstVM> GetLeaveRequestDatailByIdAsync(int id);
        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM createLeaveRequestVM);
        Task<Response<int>> EditLeaveRequestAsync(int id,UpdateLeaveRequstVM updateLeaveRequstVM);
        Task<Response<int>> ChangeApprovalAsync(int id,bool StatusApproval);
        Task<Response<int>> DeleteLeaveRequestAsync(int id);

    }
}
