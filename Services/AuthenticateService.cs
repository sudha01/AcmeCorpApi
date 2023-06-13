using AcmeCorpAPI.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace AcmeCorpAPI.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;

        private List<User> _users = new List<User>()
        {
            new User(){UserId=1, FirstName="sudhakar", LastName="koganti",
            UserName="sudhakarkoganti", Password="test@2023"}
        };

        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string userName, string pwd)
        {
            var user = _users.SingleOrDefault(usr => usr.UserName == usr.UserName && usr.Password == pwd);
            if (user == null)
                return new User();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1") }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDesc);
            user.Tocken = tokenHandler.WriteToken(token);
            user.Password = string.Empty;
            return user;

        }
    }
}
