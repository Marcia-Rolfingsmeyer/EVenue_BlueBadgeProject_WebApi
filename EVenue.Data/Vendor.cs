using EVenue.Data.JointTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Vendor's Name")]
        public string VendorName { get; set; }

        //public VendorType TypeOfVendor { get; set; }

        [Required]
        [Display(Name = "Vendor's Fee")]
        public double VendorFee { get; set; }

        public virtual List<VendorOccasion> VendorOccasions { get; set; } = new List<VendorOccasion>();
    }
}
