using AcmeCorpAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Api.Test
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        string Create(Customer customer);
        void Update(Customer customer);
        Customer Delete(int id);
    }

   
}
