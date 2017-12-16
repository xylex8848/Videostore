using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class VideoStoreDbContext:DbContext
    {
        public DbSet<Videofilm> VideoFilms { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}