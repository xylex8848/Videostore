using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class VideoCustomer
    {
        public Videofilm videofilms { get; set; }
        public Customer customers { get; set; }
    }
}