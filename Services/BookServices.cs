using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domain.Models;
using api_rest.Domain.Services;
using api_rest.Domain.Repositories;
using api_rest.Communication;

namespace api_rest.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _bookRepository.ListAsync();
        }

        public async Task<Book> FindByISBNAsync(long isbn)
        {
            return await _bookRepository.FindByISBNAsync(isbn);
        }

        public async Task<IEnumerable<Book>> FindByTitleAsync(string title)
        {
            return await _bookRepository.FindByTitleAsync(title);
        }

        public async Task<BookResponse> SaveAsync(Book book)
        {
            try
            {
                await _bookRepository.AddAsync(book);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(book);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BookResponse($"An error occurred when saving the book: {ex.Message}");
            }
        }

        public async Task<BookResponse> UpdateAsync(long isbn, Book book)
        {
            var existingBook = await _bookRepository.FindByISBNAsync(isbn);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.Description = book.Description;
            existingBook.Pages = book.Pages;
            existingBook.Rating = book.Rating;
            existingBook.Count = book.Count;

            try
            {
                _bookRepository.Update(existingBook);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BookResponse($"An error occurred when updating the book: {ex.Message}");
            }
        }

        public async Task<BookResponse> DeleteAsync(long isbn)
        {
            var existingBook = await _bookRepository.FindByISBNAsync(isbn);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            try
            {
                _bookRepository.Remove(existingBook);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BookResponse($"An error occurred when deleting the book: {ex.Message}");
            }
        }

    }
}
