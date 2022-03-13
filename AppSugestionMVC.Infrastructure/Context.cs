using AppSugestionMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSugestionMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationType> ApplicationTypes { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ////Example data
            builder.Entity<Application>()
                .HasData(
                    new Application
                    {
                        Id = 1,
                        Title = "Railway tracking app",
                        Description = "Citizens of metropolitan cities are heavily dependent on trains to get to their destination. " +
                        "It can be incredibly disruptive if the trains are late and you have no way of knowing if you should wait " +
                        "or consider an alternative way of getting to your destination. A railway tracking app can give you the exact " +
                        "time of where the train is, so if you have an emergency and the train is late you can take a bus or a taxi.",
                        ApplicationTypeId = 1
                    },

                    new Application
                    {
                        Id = 2,
                        Title = "Voice translation app",
                        Description = "One of the primary concern of travelling abroad is not knowing the language of the country and " +
                        "the struggle of trying to communicate with the natives. An app that can translate your voice will be a revolutionary " +
                        "way to communicate for travellers. The words can be spoken to the phone which will be translated to their desired " +
                        "language. The app must also work both ways where other languages can be translated to your language in real-time.",
                        ApplicationTypeId = 2
                    },

                    new Application
                    {
                        Id = 3,
                        Title = "Criminal alert app",
                        Description = "Seeing a missing person or a wanted criminals’ face once on the television is difficult to remember." +
                        " Plus, there is also a chance of meeting a stranger who turns out to be a criminal that you " +
                        "don’t know about. An application idea is such that the app will alert you of criminals in your area- so that you " +
                        "can save a life as well as help in catching a lawbreaker.",
                        ApplicationTypeId = 1
                    }
                );

            builder.Entity<ApplicationType>()
                .HasData(
                    new ApplicationType
                    {
                        Id = 1,
                        Name = "Mobile",
                    },

                    new ApplicationType
                    {
                        Id = 2,
                        Name = "Website"
                    }
                );
        }
    }
}
