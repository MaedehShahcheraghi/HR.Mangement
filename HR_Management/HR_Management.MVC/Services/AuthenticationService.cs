
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR_Management.MVC.Services
{
    public class AuthenticationService : BaseHttpService, HR_Management.MVC.Contracts.IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthenticationService(ILocalStorageService localStorage,IClient client,IHttpContextAccessor httpContextAccessor
            ):base(client,localStorage)
        {
            this._httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(string email, string password)
        {
           try
            {
                AuthRequest authRequest = new()
                {
                    Email = email,
                    Password = password
                };
                var response=await client.LoginAsync(authRequest);
                if(response.Token != string.Empty)
                {
                    var content= _jwtSecurityTokenHandler.ReadJwtToken(response.Token);
                    var claims=ParseClaim(content);
                    var user= new ClaimsPrincipal(new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme));
                    var login=  _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,user);
                    localStorage.SeTStorgeValue<string>("Token",response.Token);

                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }
        }

        public async Task LogOut()
        {
            localStorage.ClearStorage(new List<string> { "Token" });
           await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterVM registerVM)
        {
            try
            {
                RegisterationRequest registerationRequest = new RegisterationRequest()
                {
                    Email =registerVM.Email,
                    FirsteName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    UserName = registerVM.UserName,
                    Password = registerVM.Password
                };
                var response = await client.RegisterAsync(registerationRequest);
                if (response.UserId != null)
                {
                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }

        }

        #region Utility
        private IList<Claim> ParseClaim(JwtSecurityToken jwtToken)
        {
            var claims = jwtToken.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, jwtToken.Subject));
            return claims;
        }
        #endregion
    }
}
