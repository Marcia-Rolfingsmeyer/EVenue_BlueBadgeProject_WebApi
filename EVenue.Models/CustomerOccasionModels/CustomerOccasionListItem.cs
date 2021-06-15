using EVenue.Models.CustomerModels;
using EVenue.Models.OccasionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.CustomerOccasionModels
{
    public class CustomerOccasionListItem
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public CustomerListItem Customer { get; set; }

        public int OccasionId { get; set; }
        public OccasionListItem Occasion { get; set; }

        public string FullName { get; set; }
    }
}
