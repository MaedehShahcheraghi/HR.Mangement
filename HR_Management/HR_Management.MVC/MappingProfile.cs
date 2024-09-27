using AutoMapper;
using HR_Management.MVC.Models;
using HR_Management.MVC.Models.LeaaveRequestModels;
using HR_Management.MVC.Models.LeaveAllocationModel;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
                CreateMap<CreateLeaveTypeDto, CreateLeaveTypeDtoVm>().ReverseMap();
                CreateMap<LeaveTypeDto, LeaveTypeDtoVm>().ReverseMap();

            #region LeaveRequset
            CreateMap<LeaveRequestListDto, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveRequestDto, UpdateLeaveRequstVM>().ReverseMap();
            CreateMap<CreateLeaveRequestsDto, CreateLeaveRequestVM>().ReverseMap();
            CreateMap<UpdateLeaveRequestDto, UpdateLeaveRequstVM>().ReverseMap();

            #endregion
            #region LeaveAllocation
            CreateMap<LeaveAllocationDto,LeaveAllocationVM>().ReverseMap();
            CreateMap<UpdateLeaveAllocationDto,EditLeaveAllocationVM>().ReverseMap();
            CreateMap<CreateLeaveAllocationDto,CreateLeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocationDto,EditLeaveAllocationVM>().ReverseMap();

            #endregion
        }
    }
}
