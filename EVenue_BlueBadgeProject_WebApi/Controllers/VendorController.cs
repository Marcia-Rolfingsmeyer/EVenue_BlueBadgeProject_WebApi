using EVenue.Models.VendorModels;
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
    [RoutePrefix("api/Vendor")]
    public class VendorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(VendorCreate vendor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVendorService();

            if (!service.CreateVendor(vendor))
                return InternalServerError();

            return Ok(vendor);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var service = CreateVendorService();
            var v = service.GetVendors();
            return Ok(v);
        }

        [HttpGet]
        [Route("api/Vendor/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var service = CreateVendorService();
            var vendor = service.GetById(id);

            if (vendor == null)
                return NotFound();

            return Ok(vendor);
        }

        [HttpPut]
        public IHttpActionResult Put(VendorEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVendorService();

            if (!service.UpdateVendor(model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVendorService();

            if (!service.DeleteVendor(id))
                return InternalServerError();

            return Ok();
        }

        private VendorService CreateVendorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var vendorService = new VendorService(userId);
            return vendorService;
        }
    }
}
