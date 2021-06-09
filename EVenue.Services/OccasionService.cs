﻿using EVenue.Data;
using EVenue.Models.OccasionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class OccasionService
    {
        //declare userId field
        private readonly Guid _userId;

        //constructor to set userId field
        public OccasionService(Guid userId)
        {
            _userId = userId;
        }

        //CRUD methods
        //CREATE/POST
        public bool CreateOccasion(OccasionCreate model)
        {
            var entity = new Occasion
            {
                OwnerId = _userId,
                OccasionName = model.OccasionName,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                VenueProfileId = model.VenueProfileId,
                CustomerId = model.CustomerId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Occasions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //READ/GET
        //GetAllOccasions
        public IEnumerable<OccasionListItem> GetAllOccasions()
        {
            using (var ctx = new ApplicationDbContext()) {
                var query = ctx
                            .Occasions
                            .Where(e => e.OwnerId == _userId)
                            .Select(e => new OccasionListItem
                            {
                                OccasionId = e.OccasionId,
                                OccasionName = e.OccasionName,
                                StartTime = e.StartTime
                            });
                return query.ToArray();

            }
        }
    }
}
