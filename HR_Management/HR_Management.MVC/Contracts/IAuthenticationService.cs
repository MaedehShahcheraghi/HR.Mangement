using HR_Management.MVC.Models;

namespace HR_Management.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM registerVM);
        Task LogOut();


    }
}
