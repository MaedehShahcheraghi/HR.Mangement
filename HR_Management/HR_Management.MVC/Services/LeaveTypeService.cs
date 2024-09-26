using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper mapper;
        private readonly IClient client;
        private readonly ILocalStorageService localStorageService;

        public LeaveTypeService(IMapper mapper,IClient client,ILocalStorageService localStorageService):base(client,localStorageService)
        {
            this.mapper = mapper;
            this.client = client;
            this.localStorageService = localStorageService;
        }
        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeDtoVm leaveTypeDtoVm)
        {

            try
            {
                var response = new Response<int>();
                var leavetype = mapper.Map<CreateLeaveTypeDto>(leaveTypeDtoVm);
                AddBarerToken();
                var result = await client.LeaveTypePOSTAsync(leavetype);
                if (result.Success) { 
                    response.Data=result.Id;
                    response.Success = true;
                    
                }else { 
                    response.Success=false;
                    foreach (var error in result.ErrorMessage) { 
                        response.ValidationErrors=error+Environment.NewLine;
                    }

                }
                return response;
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeavetype(int id)
        {
            try
            {
                AddBarerToken();
                var response = new Response<int>();
                await client.LeaveTypeDELETEAsync(id);
                response.Success = true;
                return response;
            }
            catch (ApiException ex)
            {

                return  ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeDtoVm> GetLeaveTypeDetails(int id)
        {
            AddBarerToken();
            var leavetype=await client.LeaveTypeGETAsync(id);
            return mapper.Map<LeaveTypeDtoVm>(leavetype);  
        }

        public async Task<List<LeaveTypeDtoVm>> GetLeaveTypes()
        {
            AddBarerToken();
            var leaveTypes=await client.LeaveTypeAllAsync();
            return mapper.Map<List<LeaveTypeDtoVm>>(leaveTypes);    
        }

        public async Task<Response<int>> UpdateLeaveType(int id,LeaveTypeDtoVm leaveTypeDtoVm)
        {
            try
            {
                AddBarerToken();
                var respons=new Response<int>();
                var leavetype=mapper.Map<LeaveTypeDto>(leaveTypeDtoVm); 
                await client.LeaveTypePUTAsync(id,leavetype);
                respons.Success = true;
                return respons;

            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
