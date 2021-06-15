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

        [HttpGet]
        public IHttpActionResult Get()
        {
            var service = CreateRoomOccasionService();
            var r = service.GetRoomOccasions();
            return Ok(r);
        }

        [HttpGet]
        [Route("api/RoomOccasion/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var service = CreateRoomOccasionService();
            var entity = service.GetRoomOccasionById(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPut]
        public IHttpActionResult Put(RoomOccasionEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoomOccasionService();

            if (!service.UpdateRoomOccasion(model))
                return InternalServerError();

            return Ok($"You successfully updated Id{model.Id}!");
        }

        [HttpDelete]
        [Route("api/RoomOccasion/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRoomOccasionService();

            if (!service.DeleteRoomOccasion(id))
                return InternalServerError();

            return Ok("You successfully DELETED the RoomOccasion entity!");
        }


        private RoomOccasionService CreateRoomOccasionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomOccasionService(userId);
            return roomService;
        }

    }
}
