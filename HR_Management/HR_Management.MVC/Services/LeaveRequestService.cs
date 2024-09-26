using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models.LeaaveRequestModels;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveRequestService:BaseHttpService,ILeaveRequestService
    {
        private readonly IMapper mapper;

        public LeaveRequestService(IClient client,ILocalStorageService localStorage,
            IMapper mapper):base(client,localStorage)
        {
            this.mapper = mapper;
        }

        public async Task<Response<int>> ChangeApprovalAsync(int id, bool StatusApproval)
        {

            try
            {
                Response<int> response = new Response<int>();
                var mapping = new ChangeLeaveRequestApprovalDto()
                {
                    Approved = StatusApproval,
                    Id = id
                };
                await client.ChangeApprovalAsync(id,mapping);
                response.Success = true;
                response.Message = "Edit SuccessFully ";
                return response;

            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM createLeaveRequestVM)
        {
            try
            {
                Response<int>response=new Response<int>();
                var mapleaverequst = mapper.Map<CreateLeaveRequestsDto>(createLeaveRequestVM);
                var baseResponse = await client.LeaveRequestPOSTAsync(mapleaverequst);
                if (baseResponse.Success)
                {
                    response.Success = true;
                    response.Message = baseResponse.Message;
                    response.Data = baseResponse.Id;
                }
                else { 
                    response.Success = false;
                    response.ValidationErrors = baseResponse.ErrorMessage.Any().ToString();
                }
                return response;
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveRequestAsync(int id)
        {
            try
            {
                Response<int> response = new Response<int>();
                await client.LeaveRequestDELETEAsync(id);
                response.Success = true;
                response.Message = "Edit SuccessFully ";
                return response;

            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> EditLeaveRequestAsync(int id, UpdateLeaveRequstVM updateLeaveRequstVM)
        {
            try
            {
                Response<int> response = new Response<int>();
                var mapping=mapper.Map<UpdateLeaveRequestDto>(updateLeaveRequstVM);
                await client.LeaveRequestPUTAsync(id, mapping);
                response.Success = true;
                response.Message = "Edit SuccessFully ";
                return response;
               
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<LeaveRequestVM>> GetLeaveRequestAsync()
        {
            var leaveRequsts = await client.LeaveRequestAllAsync();
            var map= mapper.Map<List<LeaveRequestVM>>(leaveRequsts);
            return map;

        }

        public async Task<UpdateLeaveRequstVM> GetLeaveRequestDatailByIdAsync(int id)
        {
            var leaveRequsts = await client.LeaveRequestGETAsync(id);
            var map = mapper.Map<UpdateLeaveRequstVM>(leaveRequsts);
            return map;
        }
    }
}
