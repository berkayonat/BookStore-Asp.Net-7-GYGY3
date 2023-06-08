using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int>, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<Book>()
                .HasOne<Publisher>(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            builder.Entity<Book>()
                .HasMany<Author>(b => b.Authors)
                .WithMany(a => a.Books);

            builder.Entity<Book>()
                .HasOne<Genre>(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);

            builder.Entity<Book>()
                .Property(b => b.Title) 
                .IsRequired()
                .HasMaxLength(150);
            builder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<Publisher>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<AppUser>()
                .Property(a => a.FirstName)
                .HasMaxLength(150);
            builder.Entity<AppUser>()
                .Property(a => a.LastName)
                .HasMaxLength(150);

        }
    }
}
