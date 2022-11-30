using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_rest.Domain.Models;


namespace api_rest.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>().HasKey(b => b.ISBN);
            builder.Entity<Book>().Property(b => b.ISBN).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Book>().Property(b => b.Author).IsRequired().HasMaxLength(100);
            builder.Entity<Book>().Property(b => b.Genre).IsRequired().HasMaxLength(100);
            builder.Entity<Book>().Property(b => b.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Book>().Property(b => b.Pages).IsRequired();
            builder.Entity<Book>().Property(b => b.Rating).IsRequired();
            builder.Entity<Book>().Property(b => b.Count).IsRequired();

            builder.Entity<Book>().HasData
            (
                new Book { ISBN = 1, Title = "Harry Potter e a Pedra Filosofal", Author = "J. K. Rowling", Genre = "Magia", Description = "O livro conta a história de Harry Potter, um órfão criado pelos tios que descobre, em seu décimo primeiro aniversário, que é um bruxo.", Pages = 317, Rating = 4.9, Count = 7 },
                new Book { ISBN = 2, Title = "A Culpa É das Estrelas", Author = "John Green", Genre = "Romance", Description = "A Culpa É das Estrelas é o sexto romance de John Green, publicado em janeiro de 2012.", Pages = 266, Rating = 4.8, Count = 12 }
            );
        }
    
    }
}
