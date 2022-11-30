using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_rest.Domain.Services;
using api_rest.Domain.Models;
using AutoMapper;
using api_rest.Resources;
using api_rest.Extensions;

namespace api_rest.Controllers
{
    [Route("/api/[controller]")]
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookResource>> GetAllAsync()
        {
            var categories = await _bookService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(categories);

            return resources;
        }

        [HttpGet("{isbn}")]
        public async Task<BookResource> GetByISBNAsync(long isbn)
        {
            var book = await _bookService.FindByISBNAsync(isbn);
            var resources = _mapper.Map<Book, BookResource>(book);

            return resources;
        }

        [HttpGet("GetByTitle/{title}")]
        public async Task<IEnumerable<BookResource>> GetByTitleAsync(string title)
        {
            var categories = await _bookService.FindByTitleAsync(title);
            var resources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(categories);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBookResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var book = _mapper.Map<SaveBookResource, Book>(resource);
            var result = await _bookService.SaveAsync(book);

            if (!result.Success)
                return BadRequest(result.Message);

            var bookResource = _mapper.Map<Book, BookResource>(result.Book);

            return Ok(bookResource);

        }

        [HttpPut("{isbn}")]
        public async Task<IActionResult> PutAsync(long isbn, [FromBody] SaveBookResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var book = _mapper.Map<SaveBookResource, Book>(resource);
            var result = await _bookService.UpdateAsync(isbn, book);

            if (!result.Success)
                return BadRequest(result.Message);

            var bookResource = _mapper.Map<Book, BookResource>(result.Book);
            return Ok(bookResource);
        }

        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteAsync(int isbn)
        {
            var result = await _bookService.DeleteAsync(isbn);

            if (!result.Success)
                return BadRequest(result.Message);

            var bookResource = _mapper.Map<Book, BookResource>(result.Book);
            return Ok(bookResource);
        }

    }

}
