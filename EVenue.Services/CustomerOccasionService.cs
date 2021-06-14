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
                    CustomerId = model.CustomerId,
                    OccasionId = model.OccasionId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerOccasions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
