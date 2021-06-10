using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EVenue.Services;
using EVenue.Models.VenueProfileModels;

namespace EVenue_BlueBadgeProject_WebApi.Controllers
{
    [Authorize]
    public class VenueProfileController : ApiController
    {
        private VenueProfileService CreateVenueProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var venueProfileService = new VenueProfileService(userId);
            return venueProfileService;
        }

        public IHttpActionResult Post(VenueProfileCreate venueProfile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVenueProfileService();

            if (!service.CreateVenueProfile(venueProfile))
                return InternalServerError();

            return Ok(venueProfile);
        }

        public IHttpActionResult Get()
        {
            VenueProfileService venueProfileService = CreateVenueProfileService();
            var venueProfile = venueProfileService.GetVenueProfile();
            return Ok(venueProfile);
        }

        public IHttpActionResult Put(VenueProfileEdit venueProfile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVenueProfileService();

            if (!service.UpdateVenueProfile(venueProfile))
                return InternalServerError();

            return Ok(venueProfile);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateVenueProfileService();

            if (!service.DeleteVenueProfile(id))
                return InternalServerError();

            return Ok();
        }
    }
}