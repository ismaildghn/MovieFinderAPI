using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DVDRentalAPI.Domain.Entities;
using DVDRentalAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DVDRentalAPI.Persistence.Context
{
    public class DVDRentalAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public DVDRentalAPIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilmCategory>()
                .HasKey(fc => new { fc.CategoryId, fc.FilmId });

            builder.Entity<FilmCategory>()
                .HasOne(fc => fc.Film)
                .WithMany(f => f.FilmCategory)
                .HasForeignKey(fc => fc.FilmId);
            builder.Entity<FilmCategory>()
                .HasOne(fc => fc.Category)
                .WithMany(c => c.FilmCategory)
                .HasForeignKey(fc => fc.CategoryId);

            builder.Entity<FilmActor>()
                .HasKey(fa => new { fa.FilmId, fa.ActorId });

            builder.Entity<FilmActor>()
                .HasOne(fa => fa.Film)
                .WithMany(f => f.FilmActor)
                .HasForeignKey(fa => fa.FilmId);
            builder.Entity<FilmActor>()
                .HasOne(fa => fa.Actor)
                .WithMany(a => a.FilmActor)
                .HasForeignKey(fa => fa.ActorId);

            builder.Entity<Film>()
                .HasOne(f => f.Language)
                .WithMany(l => l.Film)
                .HasForeignKey(f => f.LanguageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<IdentityUserLogin<string>>()
        .HasKey(login => new { login.LoginProvider, login.ProviderKey });

            builder.Entity<IdentityUserRole<string>>()
                .HasKey(userRole => new { userRole.UserId, userRole.RoleId });

            builder.Entity<IdentityUserToken<string>>()
                .HasKey(token => new { token.UserId, token.LoginProvider, token.Name });

        }
    }
}
