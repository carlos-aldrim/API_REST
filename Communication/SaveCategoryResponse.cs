using api_rest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Communication
{
    public class BookResponse : BaseResponse
    {
        public Book Book { get; private set; }

        private BookResponse(bool success, string message, Book book) : base(success, message)
        {
            Book = book;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="book">Saved book.</param>
        /// <returns>Response.</returns>
        public BookResponse(Book book) : this(true, string.Empty, book)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BookResponse(string message) : this(false, message, null)
        { }
    }
}
