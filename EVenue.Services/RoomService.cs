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

        public IEnumerable<Room> GetRooms()
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
                                TypeOfRoom = e.TypeOfRoom,
                                PricePerHour = e.PricePerHour,
                                BasePricePerDay = e.BasePricePerDay
                            });

                return query.ToArray();
            }
        }
    }
}
