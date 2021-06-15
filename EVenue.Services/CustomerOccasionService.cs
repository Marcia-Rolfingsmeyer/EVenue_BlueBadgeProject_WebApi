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
                    .CustomerOccasions.ToArray();
                    return query
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                    e => 
                    new CustomerOccasionListItem
                    {
                        Id = e.Id,
                        CustomerId = e.CustomerId,
                        Customer = new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            FullName = e.Customer.FullName(),
                            CustomerPhone = e.Customer.CustomerPhone,
                        },
                        OccasionId = e.OccasionId,
                        Occasion = new OccasionListItem
                        {
                            OccasionId = e.OccasionId,
                            OccasionName = e.Occasion.OccasionName,
                            StartTime = e.Occasion.StartTime
                        }
                    }).ToArray();
            }
        }

        public CustomerOccasionDetail GetCustomerOccasionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .CustomerOccasions
                    .SingleOrDefault(e => e.Id == id && e.OwnerId == _ownerId);
                return
                    new CustomerOccasionDetail
                    {
                        Id = entity.Id,
                        CustomerId = entity.CustomerId,
                        Customer = new CustomerListItem
                        {
                            CustomerId = entity.Customer.CustomerId,
                            FullName = entity.Customer.FullName(),
                            CustomerPhone = entity.Customer.CustomerPhone,
                            CustomerEmail = entity.Customer.CustomerEmail
                        },
                        OccasionId = entity.OccasionId,
                        Occasion = new OccasionListItem
                        {
                            OccasionId = entity.Occasion.OccasionId,
                            OccasionName = entity.Occasion.OccasionName,
                            StartTime = entity.Occasion.StartTime
                        }
                    };
            }
        }

        public bool UpdateCustomerOccasion(CustomerOccasionDetail updateEntity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .CustomerOccasions
                    .SingleOrDefault(e => e.Id == updateEntity.Id && e.OwnerId == _ownerId);

                entity.CustomerId = updateEntity.CustomerId;
                entity.OccasionId = updateEntity.OccasionId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomerOccasion (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CustomerOccasions
                    .Single(e => e.Id == id && e.OwnerId == _ownerId);
                ctx.CustomerOccasions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
