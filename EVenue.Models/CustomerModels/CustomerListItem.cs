using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.CustomerModels
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        //[Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        //[Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
