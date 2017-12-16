using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class VideoStoreDataContextInitializer : DropCreateDatabaseAlways<VideoStoreDbContext>
    {
        protected override void Seed(VideoStoreDbContext context)
        {
            base.Seed(context);

            Customer Customer1;
            Customer Customer2;
            context.Customers.Add(Customer1 = new Customer() { Name = "First Customer", BirthDate = DateTime.Parse("2001-01-01")});
            context.Customers.Add(Customer2 = new Customer() { Name = "second Customer", BirthDate = DateTime.Parse("2001-01-01")});


            Videofilm video3 = new Videofilm() { Title = "Third film", Genre = "Third Genre", Releasedate = DateTime.Parse("1905-01-01"),Customer=Customer1 };
            Videofilm video4 = new Videofilm() { Title = "Fourth film", Genre = "Fourth Genre", Releasedate = DateTime.Today,Customer=Customer1 };
            context.VideoFilms.Add(video3);
            context.VideoFilms.Add(video4);
            context.VideoFilms.Add(new Videofilm() { Title = "First film", Genre = "First Genre", Releasedate = DateTime.Today,Customer=Customer2 });
            context.VideoFilms.Add(new Videofilm() { Title = "Second film", Genre = "Second Genre", Releasedate = DateTime.Today,Customer=Customer2 });
        }

    }
}