﻿using EVenue.Models.OccasionModels;
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
    public class OccasionController : ApiController
    {
        //method to create occasion service for a particular user
        private OccasionService CreateOccasionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OccasionService(userId);
            return service;
        }

        //POST
        public IHttpActionResult Post(OccasionCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateOccasionService();
            if (!service.CreateOccasion(model)) return InternalServerError();
            return Ok("Occasion was successfully created!");
        }
    }
}
