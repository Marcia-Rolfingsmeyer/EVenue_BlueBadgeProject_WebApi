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
                TypeOfRoom = model.TypeOfRoom,
                PricePerHour = model.PricePerHour,
                BasePricePerDay = model.BasePricePerDay,
                MaxCapacity = model.MaxCapacity
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
                                    TypeOfRoom = e.TypeOfRoom
                                });

                return query.ToArray();
            }
        }

        //GET By Id
        public RoomDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Rooms
                            .SingleOrDefault(e => e.RoomId == id && e.OwnerId == _ownerId);

                return
                    new RoomDetail
                    {
                        RoomId = entity.RoomId,
                        RoomName = entity.RoomName,
                        Description = entity.Description,
                        Amenities = entity.Amenities,
                        TypeOfRoom = entity.TypeOfRoom,
                        PricePerHour = entity.PricePerHour,
                        BasePricePerDay = entity.BasePricePerDay,
                        MaxCapacity = entity.MaxCapacity
                    };
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
                            .SingleOrDefault(e => e.RoomId == updateRoom.RoomId && e.OwnerId == _ownerId);

                entity.RoomName = updateRoom.RoomName;
                entity.Description = updateRoom.Description;
                entity.Amenities = updateRoom.Amenities;
                entity.TypeOfRoom = updateRoom.TypeOfRoom;
                entity.PricePerHour = updateRoom.PricePerHour;
                entity.BasePricePerDay = updateRoom.BasePricePerDay;
                entity.MaxCapacity = updateRoom.MaxCapacity;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteRoom (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rooms
                        .SingleOrDefault(e => e.RoomId == id && e.OwnerId == _ownerId);

                ctx.Rooms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
