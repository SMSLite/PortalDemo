using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SMSLite_Portal.Server.Data;
using SMSLite_Portal.Shared.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMSLite_Portal.Server.Repository
{
    public interface ILoginRepo
    {
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
        Task<Mdl_Faculty> Getprofile();
    }

    public class LoginRepo : ILoginRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;


        public LoginRepo(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string UserName, string password)
        {
            var response = new ServiceResponse<string>();

            Mdl_Faculty user = await _context.faculty.FirstOrDefaultAsync(x => x.usr.ToLower().Equals(UserName.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else
            {
                user = await _context.faculty.Where(u => u.usr == UserName && u.pass == password).FirstOrDefaultAsync();
                if(user == null)
                {
                    response.Success = false;
                    response.Message = "Wrong password.";
                }
                else
                {
                    response.Data = CreateToken(user);
                    //response.Data = "Creating Token";
                }
            }
            return response;
        }

        private string CreateToken(Mdl_Faculty user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.FID.ToString()),
                new Claim(ClaimTypes.Name, user.nme),
                new Claim(ClaimTypes.Role, user.typ.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.phone.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        public Task<bool> UserExists(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Mdl_Faculty> Getprofile()
        {
            Mdl_Faculty user = await _context.faculty.FirstOrDefaultAsync(x => x.FID.Equals(ClaimTypes.NameIdentifier));
            user.pass = "xxxx";
            return user;
        }


    }
}
