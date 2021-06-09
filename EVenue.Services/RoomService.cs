using EVenue.Data;
using EVenue.Models.RoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class RoomService
    {
        private readonly Guid _ownerId;

        public RoomService (Guid ownerId)
        {
            _ownerId = ownerId;
        }

        // POST
        public bool CreateRoom(RoomCreate model)
        {
            var entity = new Room()
            {
                OwnerId = _ownerId,
                RoomName = model.RoomName,
                Description = model.Description,
                Amenities = model.Amenities,
                //TypeOfRoom = e.(RoomType)
                PricePerHour = model.PricePerHour,
                BasePricePerDay = model.BasePricePerDay
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rooms.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        // GET
        public IEnumerable<RoomListItem> GetRooms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rooms
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e => new RoomListItem
                            {
                                RoomId = e.RoomId,
                                RoomName = e.RoomName,
                                Description = e.Description,
                                Amenities = e.Amenities,
                                //TypeOfRoom = e.(RoomType)
                                PricePerHour = e.PricePerHour,
                                BasePricePerDay = e.BasePricePerDay
                            });

                return query.ToArray();
            }
        }

        //UPDATE
        public bool UpdateRoom(RoomEdit updateRoom)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Rooms
                            .Single(e => e.RoomId == updateRoom.RoomId && e.OwnerId == _ownerId);

                entity.RoomId = updateRoom.RoomId;
                entity.RoomName = updateRoom.RoomName;
                entity.Description = updateRoom.Description;
                entity.Amenities = updateRoom.Amenities;
                entity.PricePerHour = updateRoom.PricePerHour;
                entity.BasePricePerDay = updateRoom.BasePricePerDay;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
