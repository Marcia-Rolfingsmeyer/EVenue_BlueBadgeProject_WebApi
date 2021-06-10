﻿using EVenue.Data;
using EVenue.Models.VenueProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class VenueProfileService
    {
        private readonly Guid _ownerId;

        public VenueProfileService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateVenueProfile(VenueProfileCreate model)
        {
            var entity = new VenueProfile()
            {
                OwnerId = _ownerId,
                VenueProfileId = model.VenueProfileId,
                VenueName = model.VenueName,
                VenueContactPerson = model.VenueContactPerson,
                VenuePhone = model.VenuePhone,
                VenueAddress = model.VenueAddress,
                VenueEmail = model.VenueEmail,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.VenueProfiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VenueProfileListItem> GetVenueProfile()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .VenueProfiles
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                        new VenueProfileListItem
                        {
                            VenueProfileId = e.VenueProfileId,
                            VenueName = e.VenueName,
                            VenueContactPerson = e.VenueContactPerson,
                            VenueAddress = e.VenueAddress,
                            VenueEmail = e.VenueEmail,
                            VenuePhone = e.VenuePhone,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        });
                return query.ToArray();
            }
        }

        public bool UpdateVenueProfile(VenueProfileEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .VenueProfiles
                    .Single(e => e.VenueProfileId == model.VenueProfileId && e.OwnerId == _ownerId);

                entity.VenueName = model.VenueName;
                entity.VenueContactPerson = model.VenueContactPerson;
                entity.VenuePhone = model.VenuePhone;
                entity.VenueAddress = model.VenueAddress;
                entity.VenueEmail = model.VenueEmail;
                entity.VenueProfileId = model.VenueProfileId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteVenueProfile(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .VenueProfiles
                    .Single(e => e.VenueProfileId == venueId && e.OwnerId == _ownerId);

                ctx.VenueProfiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
