using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Customer
    {
        public  int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public  DateTime BirthDate { get; set; }
        
        public virtual List<Videofilm> Videofilms { get; set; }
    }
}