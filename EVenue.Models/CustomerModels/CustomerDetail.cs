using EVenue.Models.OccasionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.CustomerModels
{
    public class CustomerDetail
    {
        [Required]
        public int CustomerId { get; set; }
        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public List<OccasionListItem> Occasions { get; set; }

        public string FullName { get; set; }
    }
}
