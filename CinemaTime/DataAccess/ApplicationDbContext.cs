using CinemaTime.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using CinemaTime.Models.ViewModel;

namespace CinemaTime.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>().ToTable("Actor");

            modelBuilder.Entity<Category>()
        .HasMany(c => c.Movies)
        .WithOne(m => m.Category)
        .HasForeignKey(m => m.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);

            // Movie ↔ Session
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Sessions)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // CinemaHall ↔ Session
            modelBuilder.Entity<CinemaHall>()
                .HasMany(h => h.Sessions)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Cascade);

            // Session ↔ Ticket
            modelBuilder.Entity<Session>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Session)
                .HasForeignKey(t => t.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seat ↔ Ticket (واحد لواحد لكل حجز)
            modelBuilder.Entity<Seat>()
                .HasMany<Ticket>()
                .WithOne(t => t.Seat)
                .HasForeignKey(t => t.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            // User ↔ Ticket
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ticket ↔ Payment (واحد لواحد)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Payment)
                .WithOne(p => p.Ticket)
                .HasForeignKey<Payment>(p => p.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seat: Hall relationship
            modelBuilder.Entity<CinemaHall>()
                .HasMany(h => h.Seats)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.CinemaHallId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieImage>()
              .HasOne(mi => mi.Movie)
              .WithMany(m => m.AdditionalImages)
              .HasForeignKey(mi => mi.MovieId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movie>()
    .Property(m => m.Price)
    .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
              .Property(p => p.Amount)
              .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Session>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<MovieActor>()
       .HasKey(ma => new { ma.MovieId, ma.ActorId });

            // علاقات Movie - MovieActor - Actor
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);
        }
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CinemaTime;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
      
      
    }
}
