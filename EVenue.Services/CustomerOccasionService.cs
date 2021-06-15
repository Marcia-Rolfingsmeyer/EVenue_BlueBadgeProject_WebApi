using EVenue.Data;
using EVenue.Data.JointTables;
using EVenue.Models.CustomerOccasionModels;
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
                    .CustomerOccasions.ToArray();

                return query.Select(
                    e =>
                    new CustomerOccasionListItem
                    {
                        Id = e.Id,
                        CustomerId = e.CustomerId,
                        Customer = new Models.CustomerModels.CustomerListItem
                        {
                            
                            CustomerId = e.CustomerId
                        },
                        OccasionId = e.OccasionId,
                        Occasion = new Models.OccasionModels.OccasionListItem
                        {
                            OccasionName = e.Occasion.OccasionName,
                            OccasionId = e.OccasionId
                        }
                    }).ToArray();
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
                        CustomerId = entity.CustomerId,
                        Customer = new Models.CustomerModels.CustomerListItem
                        {
                            //CustomerFirstName = entity.CustomerFirstName,
                            CustomerId = entity.CustomerId
                        },
                        OccasionId = entity.OccasionId,
                        Occasion = new Models.OccasionModels.OccasionListItem
                        {
                            OccasionName = entity.Occasion.OccasionName,
                            OccasionId = entity.OccasionId
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
                    .Single(e => e.Id == customerOccasionId);
                ctx.CustomerOccasions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
