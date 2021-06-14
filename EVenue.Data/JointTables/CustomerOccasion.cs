using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data.JointTables
{
    public class CustomerOccasion
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Occasion))]
        public int OccasionId { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}
