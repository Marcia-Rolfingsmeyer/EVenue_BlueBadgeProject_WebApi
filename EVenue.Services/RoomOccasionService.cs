using EVenue.Data;
using EVenue.Data.JointTables;
using EVenue.Models.RoomOccasionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class RoomOccasionService
    {
        private readonly Guid _ownerId;

        public RoomOccasionService(Guid ownerId)
        {
             _ownerId = ownerId;
        }

        public bool CreateRoomOccasion(RoomOccasionCreate model)
        {
            var entity = new RoomOccasion()
            {
                OwnerId = _ownerId,
                RoomId = model.RoomId,
                OccasionId = model.OccasionId
            };

            using( var ctx = new ApplicationDbContext())
            {
                ctx.RoomOccasions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<RoomOccasionListItem> GetRoomOccasions()
        //{ 
            
        //}
            
    }
}
