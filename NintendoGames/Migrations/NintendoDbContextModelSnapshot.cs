﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NintendoGames.Entities;

#nullable disable

namespace NintendoGames.Migrations
{
    [DbContext(typeof(NintendoDbContext))]
    partial class NintendoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NintendoGames.Entities.Developers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("NintendoGames.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RatingId")
                        .IsUnique();

                    b.ToTable("Game");
                });

            modelBuilder.Entity("NintendoGames.Entities.Genres", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("NintendoGames.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CriticRating")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMustPlay")
                        .HasColumnType("bit");

                    b.Property<double?>("UserScore")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("NintendoGames.Entities.Developers", b =>
                {
                    b.HasOne("NintendoGames.Entities.Game", "Game")
                        .WithMany("Developers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("NintendoGames.Entities.Game", b =>
                {
                    b.HasOne("NintendoGames.Entities.Rating", "Rating")
                        .WithOne("Game")
                        .HasForeignKey("NintendoGames.Entities.Game", "RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("NintendoGames.Entities.Genres", b =>
                {
                    b.HasOne("NintendoGames.Entities.Game", "Game")
                        .WithMany("Genres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("NintendoGames.Entities.Game", b =>
                {
                    b.Navigation("Developers");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("NintendoGames.Entities.Rating", b =>
                {
                    b.Navigation("Game");
                });
#pragma warning restore 612, 618
        }
    }
}
