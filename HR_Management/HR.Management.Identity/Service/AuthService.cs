using HR.Management.Identity.Models;
using HR_Management.Application.Constants;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Identity.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSetting options;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthService(UserManager<ApplicationUser> userManager,IOptions<JWTSetting> options,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.options = options.Value;
            this.signInManager = signInManager;
        }

        #region Register
        public async Task<RegisterationResponse> Register(RegisterationRequest request)
        {
            var exsitUserName = await userManager.FindByNameAsync(request.UserName);
            if (exsitUserName != null)
            {
                throw new Exception($"the userName {request.UserName} alreay exsit");
            }
            var exsitEamil = await userManager.FindByEmailAsync(request.Email);
            if (exsitEamil != null)
            {
                throw new Exception($"the Email {request.Email} alreay exsit");
            }
            var user = new ApplicationUser()
            {
                Id = "0294cf31-f7ee-42bf-a75d-e0119c69e4dc",
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirsteName,
                LastName = request.LastName
            };
            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Employee");
                return new RegisterationResponse()
                {
                    UserId = user.Id
                };
            }
            else
            {
                throw new Exception($"creation failed {result.Errors}");
            }
        }
        #endregion

        #region Login
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null) {
                throw new Exception($"the user with {request.Email} not found.");
            }
            var result=await signInManager.PasswordSignInAsync(user.UserName, request.Password,false,false);
            if (!result.Succeeded) { 
                throw new Exception($"Credentials for the {user.UserName} is not valid.");
            }
            var jwttoken = await GenerateToken(user);
            var respons = new AuthResponse()
            {
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwttoken)
            };
            return respons;


        }
        #endregion

        #region Utilites
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var Userclaims=await userManager.GetClaimsAsync(user);
            var roles=await userManager.GetRolesAsync(user);
            var Roleclaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                Roleclaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid,user.Id),

            }.Union(Userclaims).Union(Roleclaims);

            var symmetricSecurityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var signinCredentials=new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            var JwtSecurityToken = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(options.DurationInMinutes),
                signingCredentials: signinCredentials
                );
            return JwtSecurityToken;

        }
        #endregion
    }
}
