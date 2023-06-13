using Microsoft.Build.Execution;

namespace AcmeCorpAPI.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? EmailId { get; set; }
    }

    //public class User
    //{
    //    public int UserId { get; set; }

    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string UserName { get; set; }

    //    public string Password { get; set; }
    //    public string Token { get; set; }

    //}
}
