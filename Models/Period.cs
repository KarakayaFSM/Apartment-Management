using System;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class Period
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime PeriodDate { get; set; }
    }
}
