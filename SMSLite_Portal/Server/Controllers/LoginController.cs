using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSLite_Portal.Server.Repository;
using SMSLite_Portal.Shared.Models;
using SMSLite_Portal.Shared.ViewModels;
using System.Threading.Tasks;

namespace SMSLite_Portal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepo _LoginRepo;

        public LoginController(ILoginRepo loginRepo)
        {
            _LoginRepo = loginRepo;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            var response = await _LoginRepo.Login(request.UserName, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("getprofile")]
        public async Task<IActionResult> getprofile()
        {
            Mdl_Faculty fac = await _LoginRepo.Getprofile();
            return Ok(fac);
        }



    }
}
