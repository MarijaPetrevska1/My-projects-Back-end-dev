using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.DataAccess
{
    // NotesAppDbContext is the connection between the code and the database
    // DbContext => osnovna EF klasa
    // DbContextOptions => kazuva koja klasa i kakov provider (SQL Server)
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet se tabelite, tabela Notes i tabela Users
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }


        // OnModelCreating, tuka so FluentAPI kazuvame pravila za tabelite

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Note
            modelBuilder.Entity<Note>()
                    .Property(x => x.Text)
                    .HasMaxLength(100)
                    .IsRequired();

            modelBuilder.Entity<Note>()
                        .Property(x => x.Priority)
                        .IsRequired();

            modelBuilder.Entity<Note>()
                        .Property(x => x.Tag)
                        .IsRequired();

            // Relacija
            // Eden Note ima eden User, eden User mozi da ima povekje notes (WithMany)
            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

            #endregion
            #region User

            modelBuilder.Entity<User>()
                        .Property(x => x.FirstName)
                        .HasMaxLength(50);

            modelBuilder.Entity<User>()
                        .Property(x => x.LastName)
                        .HasMaxLength(50);

            modelBuilder.Entity<User>()
                        .Property(x => x.Username)
                        .HasMaxLength(30)
                        .IsRequired();
            #endregion

        }
    }
}
