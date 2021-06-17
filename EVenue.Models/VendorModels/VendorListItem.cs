using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.VendorModels
{
    public class VendorListItem
    {
        public int VendorId { get; set; }

        [Display(Name = "Vendor's Name")]
        public string VendorName { get; set; }

        [Display(Name = "Vendor's Fee")]
        public double VendorFee { get; set; }
    }
}
