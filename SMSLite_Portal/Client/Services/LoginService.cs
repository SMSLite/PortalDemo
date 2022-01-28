



using SMSLite_Portal.Shared.Models;
using SMSLite_Portal.Shared.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;



namespace SMSLite_Portal.Client.Services
{
    public interface ILoginService
    {
        Task<ServiceResponse<string>> Login(LoginViewModel request);
        Task<Mdl_Faculty> GetProfile();
    }


    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;

        public LoginService(HttpClient http)
        {
            _http = http;   
        }

        public async Task<ServiceResponse<string>> Login(LoginViewModel request)
        {
            var result = await _http.PostAsJsonAsync("api/Login/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<Mdl_Faculty> GetProfile()
        {
            int x = Convert.ToInt32(ClaimTypes.NameIdentifier);

           // var result = await _http.GetFromJsonAsync($"profile/getprofile/{UserID}");
            Mdl_Faculty user = await _http.GetFromJsonAsync<Mdl_Faculty>("http://localhost:18514/api/Login/getprofile");
            //return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            return user;
        }


    }
}
