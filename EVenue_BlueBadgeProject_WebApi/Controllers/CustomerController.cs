using EVenue.Models.CustomerModels;
using EVenue.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EVenue_BlueBadgeProject_WebApi.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerService = new CustomerService(userId);
            return customerService;
        }

        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok(customer);
        }

        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.UpdateCustomer(customer))
                return InternalServerError();

            return Ok(customer);
        }
    }
}