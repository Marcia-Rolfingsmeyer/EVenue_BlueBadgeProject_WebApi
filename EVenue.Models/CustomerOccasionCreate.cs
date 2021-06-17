using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.CustomerOccasionModels
{
    public class CustomerOccasionCreate
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int OccasionId { get; set; }
    }
}
