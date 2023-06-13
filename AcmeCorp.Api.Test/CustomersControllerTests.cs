using AcmeCorpAPI.Controllers;
using AcmeCorpAPI.Data.Models;
using AcmeCorpAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Api.Test
{
    [TestClass]
    public class CustomersControllerTests
    {
        private Mock<ICustomerService> mockCustomerService = null;
        private CustomersController customerController = null;

        [TestInitialize]
        public void Initialize()
        {
            mockCustomerService = new Mock<ICustomerService>();
            customerController = new CustomersController((AcmeCorpAPI.Data.AppDbContext)mockCustomerService.Object);
        }

        [TestMethod]
        public void GetCustomers()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.GetAll()).Returns(new Customer[]
            {
                new Customer { },
                new Customer { }
            });

            // ACT
            var customers = customerController.GetCustomer();

            // ASSERT
            Assert.IsNotNull(customers);
            Assert.AreEqual(2, customers.Result.Value.Count());
        }

    }
}
