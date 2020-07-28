using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BBS.Models
{
    public class BGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Group { get; set; }
    }
}
