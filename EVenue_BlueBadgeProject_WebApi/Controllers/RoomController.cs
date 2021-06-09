using EVenue.Models.RoomModels;
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
    public class RoomController : ApiController
    {

        public IHttpActionResult Post(RoomCreate room)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoomService();

            if (!service.CreateRoom(room))
                return InternalServerError();

            return Ok(room);
        }

        public IHttpActionResult Get()
        {
            var service = CreateRoomService();
            var r = service.GetRooms();
            return Ok(r);
        }

        private RoomService CreateRoomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomService(userId);
            return roomService;
        }

    }
}
