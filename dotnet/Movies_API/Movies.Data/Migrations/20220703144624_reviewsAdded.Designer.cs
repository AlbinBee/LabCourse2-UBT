﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Movies.Data.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20220703144624_reviewsAdded")]
    partial class reviewsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Movies.Core.Domain.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("ImgPath")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Movies.Core.Domain.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfVenues")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("Movies.Core.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Movies.Core.Domain.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<int>("HallNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<int>("NumOfSeats")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("Movies.Core.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Director")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("TrailerLink")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Movies.Core.Domain.MovieReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ReviewDescription")
                        .HasColumnType("text");

                    b.Property<int>("ReviewId")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewTitle")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieReviews");
                });

            modelBuilder.Entity("Movies.Core.Domain.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CinemaId")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImgClientPath")
                        .HasColumnType("text");

                    b.Property<string>("ImgPath")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InsertedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LongId")
                        .HasColumnType("uuid");

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("MovieId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Movies.Core.Domain.Actor", b =>
                {
                    b.HasOne("Movies.Core.Domain.Movie", null)
                        .WithMany("Actors")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Movies.Core.Domain.Event", b =>
                {
                    b.HasOne("Movies.Core.Domain.Cinema", "Cinema")
                        .WithMany("Events")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Movies.Core.Domain.Hall", b =>
                {
                    b.HasOne("Movies.Core.Domain.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Movies.Core.Domain.Movie", b =>
                {
                    b.HasOne("Movies.Core.Domain.Cinema", "Cinema")
                        .WithMany("Movies")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Movies.Core.Domain.MovieReview", b =>
                {
                    b.HasOne("Movies.Core.Domain.Movie", null)
                        .WithMany("MovieReviews")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Movies.Core.Domain.Photo", b =>
                {
                    b.HasOne("Movies.Core.Domain.Cinema", null)
                        .WithMany("Photos")
                        .HasForeignKey("CinemaId");

                    b.HasOne("Movies.Core.Domain.Movie", null)
                        .WithMany("Photos")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Movies.Core.Domain.Cinema", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Halls");

                    b.Navigation("Movies");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Movies.Core.Domain.Movie", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("MovieReviews");

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
