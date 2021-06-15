using EVenue.Models.RoomOccasionModels;
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
    public class RoomOccasionController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(RoomOccasionCreate roomOccasion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoomOccasionService();

            if (!service.CreateRoomOccasion(roomOccasion))
                return InternalServerError();

            return Ok();
        }

        //[HttpGet]



        //[HttpPut]


        //[HttpDelete]



        private RoomOccasionService CreateRoomOccasionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomOccasionService(userId);
            return roomService;
        }

    }
}
