using EVenue.Data;
using EVenue.Data.JointTables;
using EVenue.Models.JTVendorOccasionModels;
using EVenue.Models.OccasionModels;
using EVenue.Models.VendorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class JTVendorOccasionService
    {
        private readonly Guid _userId;

        public JTVendorOccasionService(Guid userId)
        {
            _userId = userId;
        }

        private ApplicationDbContext _ctx = new ApplicationDbContext();

        //CREATE
        public bool CreateJTVendorOccasion(JTVendorOccasionCreate model)
        {
            var entity = new VendorOccasion
            {
                OwnerId = _userId,
                VendorId = model.VendorId,
                OccasionId = model.OccasionId
            };

            using (_ctx)
            {
                _ctx.VendorOccasions.Add(entity);
                return _ctx.SaveChanges() == 1;
            }
        }

        //GET
        public IEnumerable<JTVendorOccasionDetail> GetAllJTVendorOccasion()
        {
            using (_ctx)
            {
                var query = _ctx.VendorOccasions.Where(e => e.OwnerId == _userId)
                            .Select(e => new JTVendorOccasionDetail
                            {
                                Id = e.Id,
                                VendorId = e.VendorId,
                                Vendor = new VendorListItem
                                {
                                    VendorId = e.Vendor.VendorId,
                                    VendorName = e.Vendor.VendorName,
                                    VendorFee = e.Vendor.VendorFee
                                },
                                OccasionId = e.OccasionId,
                                Occasion = new OccasionListItem
                                {
                                    OccasionId = e.Occasion.OccasionId,
                                    OccasionName = e.Occasion.OccasionName,
                                    StartTime = e.Occasion.StartTime
                                }
                            });
                return query.ToArray();
            }
        }

        //DELETE
        public bool DeleteJTVendorOccasion(int id)
        {
            using (_ctx)
            {
                var entity = _ctx.VendorOccasions.Single(e => e.OwnerId == _userId && e.Id == id);
                _ctx.VendorOccasions.Remove(entity);
                return _ctx.SaveChanges() == 1;
            }
        }
    }
}
