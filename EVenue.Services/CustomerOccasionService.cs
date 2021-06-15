using EVenue.Data;
using EVenue.Data.JointTables;
using EVenue.Models.CustomerModels;
using EVenue.Models.CustomerOccasionModels;
using EVenue.Models.OccasionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class CustomerOccasionService
    {
        private readonly Guid _ownerId;
        public CustomerOccasionService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateCustomerOccasion(CustomerOccasionCreate model)
        {
            var entity =
                new CustomerOccasion()
                {
                    OwnerId = _ownerId,
                    CustomerId = model.CustomerId,
                    OccasionId = model.OccasionId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerOccasions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerOccasionListItem> GetCustomerOccasions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CustomerOccasions
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                    e =>
                    new CustomerOccasionListItem
                    {
                        Id = e.Id,
                        CustomerId = e.CustomerId,
                        Customer = new CustomerListItem
                        {
                            CustomerId = e.Customer.CustomerId,
                            FullName = e.Customer.FullName(),
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

        public CustomerOccasionDetail GetCustomerOccasionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CustomerOccasions
                    .Single(e => e.Id == id && e.OwnerId == _ownerId);
                return
                    new CustomerOccasionDetail
                    {
                        Id = entity.Id,
                        CustomerId = entity.Customer.CustomerId,
                        Customer = new CustomerListItem
                        {
                            CustomerId = entity.Customer.CustomerId,
                            FullName = entity.Customer.FullName()
                        },
                        OccasionId = entity.OccasionId,
                        Occasion = new OccasionListItem
                        {
                            OccasionName = entity.Occasion.OccasionName,
                            OccasionId = entity.Occasion.OccasionId
                        }
                    };
            }
        }

        public bool UpdateCustomerOccasion(CustomerOccasionDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .CustomerOccasions
                    .Single(e => e.Id == model.Id && e.OwnerId == _ownerId);

                entity.CustomerId = model.CustomerId;
                entity.OccasionId = model.OccasionId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomerOccasion (int customerOccasionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CustomerOccasions
                    .Single(e => e.Id == customerOccasionId && e.OwnerId == _ownerId);
                ctx.CustomerOccasions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
