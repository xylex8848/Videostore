using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Videofilm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Genre { get; set; }
        public DateTime? Releasedate { get; set; }        

        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}