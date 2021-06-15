using EVenue.Data;
using EVenue.Models.CustomerModels;
using EVenue.Models.OccasionModels;
using EVenue.Models.RoomModels;
using EVenue.Models.VendorModels;
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
                //CustomerId = model.CustomerId,
                //RoomId = model.RoomId,
                //VendorId = model.VendorId,
                TypeOfOccasion = model.TypeOfOccasion
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
            using (var ctx = new ApplicationDbContext())
            {
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

        //GetOccasionById
        public OccasionDetail GetOccasionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Occasions.Single(e => e.OwnerId == _userId && e.OccasionId == id);
                return new OccasionDetail
                {
                    OccasionId = entity.OccasionId,
                    OccasionName = entity.OccasionName,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    VenueProfileId = entity.VenueProfileId,
                    Customers = entity.CustomerOccasions.Select(co => new CustomerListItem
                        {
                            CustomerId = co.CustomerId,
                            CustomerFirstName = co.Customer.CustomerFirstName,
                            CustomerLastName = co.Customer.CustomerLastName,
                            CustomerPhone = co.Customer.CustomerPhone
                        }).ToList(),
                    Rooms = entity.RoomOccasions.Select(ro => new RoomListItem
                        {
                            RoomId = ro.RoomId,
                            RoomName = ro.Room.RoomName,
                            TypeOfRoom = ro.Room.TypeOfRoom,
                            MaxCapacity = ro.Room.MaxCapacity
                        }).ToList(),
                    Vendors = entity.VendorOccasions.Select(vo => new VendorListItem
                        {
                            VendorId = vo.VendorId,
                            VendorName = vo.Vendor.VendorName,
                            VendorFee = vo.Vendor.VendorFee
                        }).ToList(),
                    //CustomerId = entity.CustomerId,
                    //RoomId = entity.RoomId,
                    //VendorId = entity.VendorId,
                    TypeOfOccasion = entity.TypeOfOccasion,
                    TotalPrice = entity.TotalPrice()
                };
            }
        }

        //GetFutureOccasions
        public IEnumerable<OccasionListItem> GetFutureOccasions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Occasions
                            .Where(e => e.OwnerId == _userId && e.StartTime > DateTime.Now)
                            .Select(e => new OccasionListItem
                            {
                                OccasionId = e.OccasionId,
                                OccasionName = e.OccasionName,
                                StartTime = e.StartTime
                            });
                return query.ToArray();
            }
        }

        //UpdateOccasion
        public bool UpdateOccasion(int id, OccasionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Occasions.Single(e => e.OwnerId == _userId && e.OccasionId == id);
                entity.OccasionName = model.OccasionName;
                entity.StartTime = model.StartTime;
                entity.EndTime = model.EndTime;
                entity.VenueProfileId = model.VenueProfileId;
                //entity.CustomerId = model.CustomerId; CREATE LISTITEMS IN SERVICE AND DETAIL MODEL
                //entity.RoomId = model.RoomId;
                //entity.VendorId = model.VendorId;
                entity.TypeOfOccasion = model.TypeOfOccasion;

                return ctx.SaveChanges() == 1;
            }
        }

        //DeleteOccasion
        public bool DeleteOccasion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Occasions.Single(e => e.OwnerId == _userId && e.OccasionId == id);
                ctx.Occasions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
