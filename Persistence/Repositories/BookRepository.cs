using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domain.Repositories;
using api_rest.Domain.Models;
using api_rest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task<Book> FindByISBNAsync(long isbn)
        {
            return await _context.Books.FindAsync(isbn);
        }

        public async Task<IEnumerable<Book>> FindByTitleAsync(string title)
        {
            return await _context.Books.Where(x => x.Title.Contains(title)).ToListAsync();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }


    }

}
