using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models.LeaveAllocationModel;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService,ILeaveAllocationService
    {
        private readonly IMapper mapper;

        public LeaveAllocationService(IClient client,ILocalStorageService localStorageService,
          IMapper mapper  ):base(client,localStorageService) 
        {
            this.mapper = mapper;
        }
        public async Task<Response<int>> AddLeaveAllocation(CreateLeaveAllocationVM createLeaveAllocationVM)
        {
            try
            {
                var response=new Response<int>();
                var mappData = mapper.Map<CreateLeaveAllocationDto>(createLeaveAllocationVM);
                var baseResponse = await client.LeaveAllocationPOSTAsync(mappData);
                if (baseResponse.Success) { 
                        response.Success = true;
                        response.Message= baseResponse.Message;

                }
                else
                {
                    response.Success = false;
                    response.Message=baseResponse.Message;
                    response.ValidationErrors = baseResponse.ErrorMessage.Any().ToString();
                }

                return response;    
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveAllocation(int id)
        {
            try
            {
                var response=new Response<int>();
                await client.LeaveAllocationDELETEAsync(id);
                response.Success = true;
                response.Message = "Delete Failed";
                response.ValidationErrors = "Delete Failed";
                return response;
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> EditLeaveAllocation(int id,EditLeaveAllocationVM editLeaveAllocationVM)
        {
            try
            {
                var response = new Response<int>();
                var mapData=mapper.Map<UpdateLeaveAllocationDto>(editLeaveAllocationVM);
                await client.LeaveAllocationPUTAsync(id,mapData);
                response.Success = true;
                response.Message = "Edit Failed";
                response.ValidationErrors = "Edit Failed";
                return response;
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<LeaveAllocationVM>> GetAllLeaveAllocation()
        {
            var data=await client.LeaveAllocationAllAsync();
            var mapData = mapper.Map<List<LeaveAllocationVM>>(data);
            return mapData;
        }

        public async Task<LeaveAllocationVM> GetLeaveAllocationById(int id)
        {
            var data=await client.LeaveAllocationGETAsync(id);
            var mapData=mapper.Map<LeaveAllocationVM>(data);
            return mapData;
        }

        public async Task<EditLeaveAllocationVM> GetLeaveAllocationByIdForEdit(int id)
        {
            var data = await client.LeaveAllocationGETAsync(id);
            var mapData = mapper.Map<EditLeaveAllocationVM>(data);
            return mapData;
        }
    }
}
