using EVenue.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Services
{
    class CustomerService
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
                CustomerEmail = model.CustomerEmail
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
