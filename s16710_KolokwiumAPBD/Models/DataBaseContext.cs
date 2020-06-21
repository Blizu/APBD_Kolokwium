using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16710_KolokwiumAPBD.Models
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext() { }

        public DataBaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistEvent> ArtistsEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventOrganiser> EventOrganizers { get; set; }
        public DbSet<Organiser> Organisers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>().HasKey(k => new { k.IdArtist });
            modelBuilder.Entity<Event>().HasKey(k => new { k.IdEvent});
            modelBuilder.Entity<ArtistEvent>().HasKey(k => new { k.IdArtist, k.IdEvent});
            modelBuilder.Entity<Organiser>().HasKey(k => new { k.idOrganiser});
            modelBuilder.Entity<EventOrganiser>().HasKey(k => new { k.IdEvent, k.IdOrganiser});

            //Tworzenie relacji pomiędzy Artist - ArtistEvents - Event

            modelBuilder.Entity<ArtistEvent >()
             .HasOne<Artist>(ae => ae.Artist)
             .WithMany(ar => ar.ArtistEvents)
             .HasForeignKey(ar => ar.IdArtist);

            modelBuilder.Entity<ArtistEvent>()
                .HasOne<Event>(ae => ae.Event)
                .WithMany(ev => ev.ArtistEvents)
                .HasForeignKey(ev => ev.IdEvent);

            //Tworzenie relacji pomiędzy Event - EventOrganiser- Organiser

            modelBuilder.Entity<EventOrganiser>()
             .HasOne<Event>(eo => eo.Event)
             .WithMany(ev => ev.EventOrganisers)
             .HasForeignKey(ev => ev.IdEvent);

            modelBuilder.Entity<EventOrganiser>()
                .HasOne<Organiser>(ae => ae.Organiser)
                .WithMany(or => or.EventOrganisers)
                .HasForeignKey(or => or.IdOrganiser);
            

            // Organiczenia 

            modelBuilder.Entity<Artist>()
            .Property(s => s.NickName)
            .HasMaxLength(30);

            modelBuilder.Entity<Event>()
            .Property(s => s.Name)
            .HasMaxLength(100);

            modelBuilder.Entity<Organiser>()
            .Property(s => s.Name)
            .HasMaxLength(30);







        }


    }
}
