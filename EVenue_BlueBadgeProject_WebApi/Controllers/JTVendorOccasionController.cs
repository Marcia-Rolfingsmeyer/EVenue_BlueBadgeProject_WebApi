using EVenue.Models.JTVendorOccasionModels;
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
    public class JTVendorOccasionController : ApiController
    {
        private JTVendorOccasionService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new JTVendorOccasionService(userId);
        }

        //POST
        public IHttpActionResult Post(JTVendorOccasionCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateService();
            if (!service.CreateJTVendorOccasion(model)) return InternalServerError();
            return Ok("VendorOccasion was successfully created!");
        }

        //GET
        public IHttpActionResult GetAll()
        {
            var service = CreateService();
            return Ok(service.GetAllJTVendorOccasion());
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateService();
            if (!service.DeleteJTVendorOccasion(id)) return InternalServerError();
            return Ok("VendorOccasion was successfully deleted!");
        }
    }
}
