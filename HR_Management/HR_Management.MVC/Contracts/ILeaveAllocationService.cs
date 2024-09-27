using HR_Management.MVC.Models.LeaveAllocationModel;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveAllocationService
    {
        Task<List<LeaveAllocationVM>> GetAllLeaveAllocation();
        Task<LeaveAllocationVM> GetLeaveAllocationById(int id);
        Task<EditLeaveAllocationVM> GetLeaveAllocationByIdForEdit(int id);
        Task<Response<int>> AddLeaveAllocation(CreateLeaveAllocationVM createLeaveAllocationVM);
        Task<Response<int>> EditLeaveAllocation(int id,EditLeaveAllocationVM editLeaveAllocationVM);
        Task<Response<int>> DeleteLeaveAllocation(int id);

    }
}
