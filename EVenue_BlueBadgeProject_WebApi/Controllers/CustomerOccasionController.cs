using EVenue.Models.CustomerOccasionModels;
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
    public class CustomerOccasionController : ApiController
    {

        private CustomerOccasionService CreateCustomerOccasionService()
        {
            var userId = Guid.Parse
                (User.Identity.GetUserId());
            var customerOccasionService = new CustomerOccasionService(userId);
            return customerOccasionService;
        }
        public IHttpActionResult Get()
        {
            CustomerOccasionService customerOccasionService = CreateCustomerOccasionService();
            var customerOccasions = customerOccasionService.GetCustomerOccasions();
            return Ok(customerOccasions);
        }
        public IHttpActionResult Post(CustomerOccasionCreate customerOccasion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerOccasionService();

            if (!service.CreateCustomerOccasion(customerOccasion))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CustomerOccasionService customerOccasionService = CreateCustomerOccasionService();
            var customerOccasion = customerOccasionService.GetCustomerOccasionById(id);
            return Ok(customerOccasion);
        }
        public IHttpActionResult Put(CustomerOccasionDetail customerOccasion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCustomerOccasionService();

            if (!service.UpdateCustomerOccasion(customerOccasion))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCustomerOccasionService();

            if (!service.DeleteCustomerOccasion(id))
                return InternalServerError();
            return Ok();
        }
    }
}
