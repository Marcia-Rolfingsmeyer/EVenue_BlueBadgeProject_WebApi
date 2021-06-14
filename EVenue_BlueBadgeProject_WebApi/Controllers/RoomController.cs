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
        [HttpPost]
        public IHttpActionResult Post(RoomCreate room)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoomService();

            if (!service.CreateRoom(room))
                return InternalServerError();

            return Ok($"You succesfully created {room.RoomName}!");
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateRoomService();
            var r = service.GetRooms();
            return Ok(r);
        }

        [HttpGet]
        [Route("api/Room/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var service = CreateRoomService();
            var room = service.GetById(id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPut]
        public IHttpActionResult Put(RoomEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoomService();

            if (!service.UpdateRoom(model))
                return InternalServerError();

            return Ok($"You successfully updated {model.RoomName}!");
        }

        [HttpDelete]
        [Route("api/Room/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRoomService();

            if (!service.DeleteRoom(id))
                return InternalServerError();

            return Ok("You successfully DELETED the room entity!");
        }

        private RoomService CreateRoomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomService(userId);
            return roomService;
        }
    }
}
