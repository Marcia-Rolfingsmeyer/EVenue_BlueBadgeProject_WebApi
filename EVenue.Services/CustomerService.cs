using EVenue.Data;
using EVenue.Models.CustomerModels;
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

        public bool CreateCustomer(Models.CustomerModels.CustomerCreate model)
        {
            var entity = new Customer()
            {
                OwnerId = _ownerId,
                CustomerId = model.CustomerId,
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
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Where(e => e.OwnerId != null)
                    .Select(
                        e =>
                        new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            CustomerFirstName = e.CustomerFirstName,
                            CustomerLastName = e.CustomerLastName,
                            CustomerAddress = e.CustomerAddress,
                            CustomerEmail = e.CustomerEmail,
                            CustomerPhone = e.CustomerPhone,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        });
                return query.ToArray();
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
