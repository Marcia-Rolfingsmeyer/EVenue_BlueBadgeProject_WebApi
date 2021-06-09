using EVenue.Data;
using EVenue.Models.VendorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class VendorService
    {
        private readonly Guid _ownerId;

        public VendorService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        //POST
        public bool CreateVendor(VendorCreate model)
        {
            var entity = new Vendor()
            {
                OwnerId = _ownerId,
                VendorName = model.VendorName,
                VendorFee = model.VendorFee
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vendors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET
        public IEnumerable<VendorListItem> GetVendors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vendors
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e => new VendorListItem
                            {
                                VendorId = e.VendorId,
                                VendorName = e.VendorName,
                                VendorFee = e.VendorFee
                            });

                return query.ToArray();
            }
        }

        // GET By Id
        public VendorDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Vendors
                            .Single(e => e.VendorId == id && e.OwnerId == _ownerId);

                return
                    new VendorDetail
                    {
                        VendorId = entity.VendorId,
                        VendorName = entity.VendorName,
                        VendorFee = entity.VendorFee
                    };
            }
        }

        //UPDATE
        public bool UpdateVendor(VendorEdit updateVendor)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Vendors
                            .Single(e => e.VendorId == updateVendor.VendorId && e.OwnerId == _ownerId);

                entity.VendorId = updateVendor.VendorId;
                entity.VendorName = updateVendor.VendorName;
                entity.VendorFee = updateVendor.VendorFee;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteVendor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Vendors
                            .Single(e => e.VendorId == id && e.OwnerId == _ownerId);

                ctx.Vendors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
