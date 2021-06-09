﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.CustomerModels
{
    public class CustomerCreate
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string CustomerFirstName { get; set; }

        [Required]
        public string CustomerLastName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }
    }
}