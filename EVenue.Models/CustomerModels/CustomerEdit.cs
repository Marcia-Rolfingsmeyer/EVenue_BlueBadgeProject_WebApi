using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.CustomerModels
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        public string FullName() => $"{CustomerFirstName} {CustomerLastName}";
    }
}
