using EVenue.Data;
using EVenue.Data.JointTables;
using EVenue.Models.JTVendorOccasionModels;
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
                VendorId = model.VendorId,
                OccasionId = model.OccasionId
            };

            using (_ctx)
            {
                _ctx.VendorOccasions.Add(entity);
                return _ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        //public bool DeleteOccasion(int id)
        //{
        //    using (_ctx)
        //    {
        //        var entity = _ctx.VendorOccasions.Single(e =>)
        //    }
        //}
    }
}
