using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domain.Models;

namespace api_rest.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        Task AddAsync(Book book);
        Task<Book> FindByISBNAsync(long isbn);

        Task<IEnumerable<Book>> FindByTitleAsync(string title);
        void Update(Book book);
        void Remove(Book book);
    }
}
