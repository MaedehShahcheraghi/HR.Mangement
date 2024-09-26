using HR_Management.MVC.Contracts;
using System.Net.Http.Headers;

namespace HR_Management.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient client;
        protected readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception) {

            if (exception.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation Errors Have Accoured...", Success = false, ValidationErrors = exception.Response };
            }
            else if (exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not Found...", Success = false };

            }
            else {
                return new Response<Guid>() { Message = "Somthing Went Wrong,Try Again...", Success = false };

            }
        } 

        protected void AddBarerToken()
        {
            if (localStorage.Exsits("Token"))
            {
                client.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", localStorage.GetStorageValue<string>("Token"));
            }
        }

    }
}
