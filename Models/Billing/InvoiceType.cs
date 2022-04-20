﻿using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class InvoiceType
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Charge { get; set; }
    }
}