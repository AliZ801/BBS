using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BBS.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Blood ID")]
        public int BloodId { get; set; }

        [ForeignKey("BloodId")]
        public BGroup BGroup { get; set; }

        [Required]
        [Display(Name = "Hospital ID")]
        public int HospitalId { get; set; }

        [ForeignKey("HospitalId")]
        public Hospital Hospital { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}
