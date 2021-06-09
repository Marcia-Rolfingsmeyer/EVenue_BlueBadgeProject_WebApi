using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.VendorModels
{
    public class VendorCreate
    {
        [Required]
        [Display(Name = "Vendor's Name")]
        public string VendorName { get; set; }

        //public VendorType TypeOfVendor { get; set; }

        [Required]
        [Display(Name = "Vendor's Fee")]
        public double VendorFee { get; set; }
    }
}
