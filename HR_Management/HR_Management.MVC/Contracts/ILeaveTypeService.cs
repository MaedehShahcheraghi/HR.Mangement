using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeDtoVm>> GetLeaveTypes();
        Task<LeaveTypeDtoVm> GetLeaveTypeDetails(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeDtoVm leaveTypeDtoVm);
        Task<Response<int>> UpdateLeaveType(int id,LeaveTypeDtoVm leaveTypeDtoVm);
        Task<Response<int>> DeleteLeavetype(int id);

    }
}
