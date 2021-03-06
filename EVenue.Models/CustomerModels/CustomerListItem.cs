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

        public string FullName { get; set; }

        public string CustomerPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
    }
}
