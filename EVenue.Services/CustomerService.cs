using EVenue.Data;
using EVenue.Data.JointTables;
using EVenue.Models.CustomerModels;
using EVenue.Models.OccasionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    public class CustomerService
    {
        private readonly Guid _ownerId;

        public CustomerService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = 
                new Customer()
                {
                    OwnerId = _ownerId,
                    CustomerFirstName = model.CustomerFirstName,
                    CustomerLastName = model.CustomerLastName,
                    CustomerAddress = model.CustomerAddress,
                    CustomerPhone = model.CustomerPhone,
                    CustomerEmail = model.CustomerEmail,
                    CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                ctx.SaveChanges();
                int customerId = ctx.Customers.AsEnumerable().Last().CustomerId;
                int savedObjects = 0;
                if (model.Occasion != null)
                {
                    foreach (int occasion in model.Occasion)
                    {
                        CustomerOccasion customerOccasion = new CustomerOccasion
                        {
                            OccasionId = occasion,
                            CustomerId = customerId
                        };
                        ctx.CustomerOccasions.Add(customerOccasion);
                        ++savedObjects;
                    }
                }

                return ctx.SaveChanges() == savedObjects;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers.AsEnumerable()
                    .Where(e => e.OwnerId != null)
                    .Select(
                        e =>
                        new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            FullName = e.FullName(),
                            CustomerPhone = e.CustomerPhone
                        });
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id && e.OwnerId == _ownerId);
                return
                    new CustomerDetail
                    {
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        CustomerAddress = entity.CustomerAddress,
                        CustomerEmail = entity.CustomerEmail,
                        CustomerPhone = entity.CustomerPhone,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,

                        Occasions = entity.CustomerOccasions.Select(c => new OccasionListItem
                        {
                            OccasionId = c.OccasionId,
                            OccasionName = c.Occasion.OccasionName
                        }).ToList()
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _ownerId);

                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.CustomerAddress = model.CustomerAddress;
                entity.CustomerPhone = model.CustomerPhone;
                entity.CustomerId = model.CustomerId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteCustomer (int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == customerId && e.OwnerId == _ownerId);
                
                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
