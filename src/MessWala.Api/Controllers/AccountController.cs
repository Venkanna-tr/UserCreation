using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessWala.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/account/")]
    public class AccountController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IConfiguration configuration, ILogger<AccountController> logger)
        {
            this._configuration = configuration;
            _logger = logger;
        }

        public class LoginData
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string DeviceId { get; set; }
            public string Token { get; set; }
        }

        [HttpGet("get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("login")]
        public async Task<LoginData> Login(LoginData data)
        {
            try
            {
                _logger.LogInformation("Index page says hello");
                var res = await ValidateUser(data);
                LoginData obj = new LoginData() { UserName = data.UserName, Password = data.Password, DeviceId = data.DeviceId, Token = res };
                return obj;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task<string> ValidateUser(LoginData data)
        {
            try
            {
                var result = "Validate the user";  // validate the user
                if (result != null)
                {
                    return await GenerateToken("Email", "userId");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return string.Empty;
        }

        private async Task<string> GenerateToken(string email, string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}