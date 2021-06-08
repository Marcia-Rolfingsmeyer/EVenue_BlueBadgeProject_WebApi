using EVenue.Data;
using EVenue.Models.VenueProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    class VenueProfileService
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
                VenueEmail = model.VenueEmail
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.VenueProfiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
