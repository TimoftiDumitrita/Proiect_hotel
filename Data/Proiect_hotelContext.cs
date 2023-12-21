using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Models;

namespace Proiect_hotel.Data
{
    public class Proiect_hotelContext : DbContext
    {
        public Proiect_hotelContext (DbContextOptions<Proiect_hotelContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_hotel.Models.Camera> Camera { get; set; } = default!;

        public DbSet<Proiect_hotel.Models.Pat>? Pat { get; set; }

        public DbSet<Proiect_hotel.Models.Pret>? Pret { get; set; }

        public DbSet<Proiect_hotel.Models.Rezervare>? Rezervare { get; set; }

        public DbSet<Proiect_hotel.Models.Client>? Client { get; set; }

        public DbSet<Proiect_hotel.Models.Review>? Review { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervare_camera>()
                .HasKey(c => new { c.CameraID, c.RezervareID });
            modelBuilder.Entity<Review>()
        .HasOne(r => r.Client)
        .WithMany()
        .HasForeignKey(r => r.ClientID);
        }

        public DbSet<Proiect_hotel.Models.Rezervare_camera>? Rezervare_camera { get; set; }
    }
}
