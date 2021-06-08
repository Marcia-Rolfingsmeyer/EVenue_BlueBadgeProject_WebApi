using EVenue.Data;
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
    }
}
