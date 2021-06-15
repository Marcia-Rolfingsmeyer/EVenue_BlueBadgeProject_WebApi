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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RoomOccasions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoomOccasionListItem> GetRoomOccasions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RoomOccasions.ToArray();

                return query
                  .Where(e => e.OwnerId == _ownerId)
                  .Select(
                          e => new RoomOccasionListItem
                          {
                              Id = e.Id,
                              RoomId = e.RoomId,
                              Room = new Models.RoomModels.RoomListItem
                              {
                                  RoomId = e.Room.RoomId,
                                  RoomName = e.Room.RoomName,
                                  TypeOfRoom = e.Room.TypeOfRoom,
                                  MaxCapacity = e.Room.MaxCapacity
                              },
                              OccasionId = e.OccasionId,
                              Occasion = new Models.OccasionModels.OccasionListItem
                              {
                                  OccasionId = e.Occasion.OccasionId,
                                  OccasionName = e.Occasion.OccasionName,
                                  StartTime = e.Occasion.StartTime
                              }
                          }).ToArray();
            }
        }

        public RoomOccasionDetail GetRoomOccasionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RoomOccasions
                        .SingleOrDefault(e => e.Id == id && e.OwnerId == _ownerId);

                return
                    new RoomOccasionDetail
                    {
                        Id = entity.Id,
                        RoomId = entity.RoomId,
                        Room = new Models.RoomModels.RoomListItem
                        {
                            RoomId = entity.Room.RoomId,
                            RoomName = entity.Room.RoomName,
                            TypeOfRoom = entity.Room.TypeOfRoom,
                            MaxCapacity = entity.Room.MaxCapacity
                        },
                        OccasionId = entity.OccasionId,
                        Occasion = new Models.OccasionModels.OccasionListItem
                        {
                            OccasionId = entity.Occasion.OccasionId,
                            OccasionName = entity.Occasion.OccasionName,
                            StartTime = entity.Occasion.StartTime
                        }
                    };
            }
        }

        public bool UpdateRoomOccasion(RoomOccasionEdit updatedEntity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RoomOccasions
                        .SingleOrDefault(e => e.Id == updatedEntity.Id && e.OwnerId == _ownerId);

                entity.RoomId = updatedEntity.RoomId;
                entity.OccasionId = updatedEntity.OccasionId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoomOccasion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RoomOccasions
                        .SingleOrDefault(e => e.Id == id && e.OwnerId == _ownerId);

                ctx.RoomOccasions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
