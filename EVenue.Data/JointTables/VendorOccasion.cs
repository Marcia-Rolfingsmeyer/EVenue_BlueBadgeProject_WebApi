using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data.JointTables
{
    public class VendorOccasion
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Vendor))]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [ForeignKey(nameof(Occasion))]
        public int OccasionId { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}
