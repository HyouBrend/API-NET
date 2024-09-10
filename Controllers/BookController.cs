// File: Controllers/BookController.cs
using Microsoft.AspNetCore.Mvc;
using MoonaHoshinova.Services;
using MoonaHoshinova.Models;
using MoonaHoshinova.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonaHoshinova.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("All")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();

                // Mengonversi BookModel ke BookOutput
                var bookOutputs = books.Select(book => new BookOutput
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    AuthorBook = book.AuthorBook,
                    DescriptionBook = book.DescriptionBook,
                    CategoryBook = book.CategoryBook,
                    RelatedBookByAuthor = book.RelatedBookByAuthor.NameRelatedBook,
                    PublisherDateBook = book.PublisherDateBook.ToString("yyyy-MM-ddTHH:mm:ss"),
                    CreatedAt = book.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    UpdatedAt = book.UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                }).ToList();

                // Membuat output dengan message dan books
                var output = new BookListOutput
                {
                    Message = "Anda berhasil mengambil sebuah data",
                    Books = bookOutputs
                };

                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("SearchByRelatedName")]
        public IActionResult SearchByRelatedBookName(string relatedBookName)
        {
            try
            {
                var books = _bookService.SearchByRelatedBookName(relatedBookName);

                // Mengonversi BookModel ke BookOutput
                var bookOutputs = books.Select(book => new BookOutput
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    AuthorBook = book.AuthorBook,
                    DescriptionBook = book.DescriptionBook,
                    CategoryBook = book.CategoryBook,
                    RelatedBookByAuthor = book.RelatedBookByAuthor.NameRelatedBook,
                    PublisherDateBook = book.PublisherDateBook.ToString("yyyy-MM-ddTHH:mm:ss"),
                    CreatedAt = book.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    UpdatedAt = book.UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                }).ToList();

                // Membuat output dengan message dan books
                var output = new BookListOutput
                {
                    Message = "Anda berhasil mengambil sebuah data",
                    Books = bookOutputs
                };

                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Add")]
        public IActionResult InsertBook([FromBody] BookModel book)
        {
            try
            {
                _bookService.InsertBook(book);

                // Membuat output dengan message sukses
                var output = new
                {
                    message = "Buku berhasil ditambahkan.",
                    books = new List<BookOutput>() // Tidak ada buku yang dikembalikan dalam respon ini
                };

                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
