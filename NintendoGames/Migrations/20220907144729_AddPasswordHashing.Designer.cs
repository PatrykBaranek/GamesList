﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NintendoGames.Entities;

#nullable disable

namespace NintendoGames.Migrations
{
    [DbContext(typeof(NintendoDbContext))]
    [Migration("20220907144729_AddPasswordHashing")]
    partial class AddPasswordHashing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameWishList", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WishListsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "WishListsId");

                    b.HasIndex("WishListsId");

                    b.ToTable("GameWishList");
                });

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
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("NintendoGames.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("NintendoGames.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<Guid>("WishListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("WishListId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("NintendoGames.Entities.WishList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("GameWishList", b =>
                {
                    b.HasOne("NintendoGames.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NintendoGames.Entities.WishList", null)
                        .WithMany()
                        .HasForeignKey("WishListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("NintendoGames.Entities.User", b =>
                {
                    b.HasOne("NintendoGames.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NintendoGames.Entities.WishList", "WishList")
                        .WithOne("User")
                        .HasForeignKey("NintendoGames.Entities.User", "WishListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("WishList");
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

            modelBuilder.Entity("NintendoGames.Entities.WishList", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}