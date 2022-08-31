﻿using Microsoft.EntityFrameworkCore;

namespace NintendoGames.Entities
{
    public class NintendoDbContext : DbContext
    {
        public NintendoDbContext(DbContextOptions<NintendoDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Developers> Developers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(builder =>
            {
                builder.Property(g => g.Title)
                    .IsRequired();

                builder.Property(g => g.ReleaseDate)
                    .IsRequired();

                builder.HasOne(g => g.Rating)
                    .WithOne(r => r.Game)
                    .HasForeignKey<Rating>(r => r.GameId);

                builder.HasMany(g => g.Developers)
                    .WithOne(d => d.Game)
                    .HasForeignKey(d => d.GameId);

                builder.HasMany(g => g.Genres)
                    .WithOne(ge => ge.Game)
                    .HasForeignKey(ge => ge.GameId);
            });

            modelBuilder.Entity<Rating>(builder =>
            {
                builder.HasOne(r => r.Game)
                    .WithOne(g => g.Rating)
                    .HasForeignKey<Game>(g => g.RatingId);
            });

            modelBuilder.Entity<Genres>(builder =>
            {
                builder.HasOne(ge => ge.Game)
                    .WithMany(g => g.Genres)
                    .HasForeignKey(ge => ge.GameId);
            });

            modelBuilder.Entity<Developers>(builder =>
            {
                builder.HasOne(d => d.Game)
                    .WithMany(g => g.Developers)
                    .HasForeignKey(d => d.GameId);
            });
        }
    }
}
