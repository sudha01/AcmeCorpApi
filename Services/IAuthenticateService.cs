using AcmeCorpAPI.Data.Models;

namespace AcmeCorpAPI.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string pwd);
    }
}
