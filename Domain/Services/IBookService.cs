using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Communication;
using api_rest.Domain.Models;

namespace api_rest.Domain.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<BookResponse> SaveAsync(Book book);
        Task<Book> FindByISBNAsync(long isbn);
        Task<IEnumerable<Book>> FindByTitleAsync(string title);
        Task<BookResponse> UpdateAsync(long isbn, Book book);
        Task<BookResponse> DeleteAsync(long isbn);
    }
}
