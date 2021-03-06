﻿using conSpektas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace conSpektas.Data
{
    public class ConspectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Conspect> Conspects { get; set; }
        public DbSet<ConspectRating> ConspectsRatings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentRating> CommentsRatings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ConspectCategory> ConspectsCategories { get; set; }

        public ConspectContext(DbContextOptions<ConspectContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConspectRating>()
                .HasKey(rating => new { rating.UserId, rating.ConspectId });

            modelBuilder.Entity<CommentRating>()
                .HasKey(rating => new { rating.UserId, rating.CommentId });

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(user => user.UserName)
                .IsUnique();

            modelBuilder.Entity<ConspectCategory>()
                .HasKey(category => new { category.CategoryId, category.ConspectId });

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.User)
                .WithMany(user => user.Comments).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conspect>()
                .HasOne(conspect => conspect.Parent)
                .WithOne().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conspect>()
                .HasOne(conspect => conspect.User)
                .WithMany(user => user.Conspects).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
