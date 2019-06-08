﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using conSpektas.Data;

namespace conSpektas.Data.Migrations
{
    [DbContext(typeof(ConspectContext))]
    [Migration("20190608093306_Ratings")]
    partial class Ratings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("conSpektas.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConspectId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Rating");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConspectId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.CommentRating", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("CommentId");

                    b.Property<bool>("Positive");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentsRatings");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.Conspect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Inserted");

                    b.Property<int?>("ParentId");

                    b.Property<int>("Rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId")
                        .IsUnique()
                        .HasFilter("[ParentId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Conspects");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.ConspectCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("ConspectId");

                    b.HasKey("CategoryId", "ConspectId");

                    b.HasIndex("ConspectId");

                    b.ToTable("ConspectsCategories");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.ConspectRating", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ConspectId");

                    b.Property<bool>("Positive");

                    b.HasKey("UserId", "ConspectId");

                    b.HasIndex("ConspectId");

                    b.ToTable("ConspectsRatings");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Institution")
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("conSpektas.Data.Entities.Comment", b =>
                {
                    b.HasOne("conSpektas.Data.Entities.Conspect", "Conspect")
                        .WithMany("Comments")
                        .HasForeignKey("ConspectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("conSpektas.Data.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("conSpektas.Data.Entities.CommentRating", b =>
                {
                    b.HasOne("conSpektas.Data.Entities.Comment", "Comment")
                        .WithMany("Ratings")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("conSpektas.Data.Entities.User", "User")
                        .WithMany("CommentRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("conSpektas.Data.Entities.Conspect", b =>
                {
                    b.HasOne("conSpektas.Data.Entities.Conspect", "Parent")
                        .WithOne()
                        .HasForeignKey("conSpektas.Data.Entities.Conspect", "ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("conSpektas.Data.Entities.User", "User")
                        .WithMany("Conspects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("conSpektas.Data.Entities.ConspectCategory", b =>
                {
                    b.HasOne("conSpektas.Data.Entities.Category", "Category")
                        .WithMany("Conspects")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("conSpektas.Data.Entities.Conspect", "Conspect")
                        .WithMany("Categories")
                        .HasForeignKey("ConspectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("conSpektas.Data.Entities.ConspectRating", b =>
                {
                    b.HasOne("conSpektas.Data.Entities.Conspect", "Conspect")
                        .WithMany("Ratings")
                        .HasForeignKey("ConspectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("conSpektas.Data.Entities.User", "User")
                        .WithMany("ConspectRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
