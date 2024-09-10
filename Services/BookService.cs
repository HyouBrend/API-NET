using MoonaHoshinova.Helper;
using MoonaHoshinova.Models;
using System.Collections.Generic;

namespace MoonaHoshinova.Services
{
    public class BookService
    {
        private readonly MongoDbHelper _mongoDbHelper;

        public BookService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public List<BookModel> GetAllBooks()
        {
            return _mongoDbHelper.GetAllBooks();
        }

        public List<BookModel> SearchByRelatedBookName(string relatedBookName)
        {
            return _mongoDbHelper.SearchByRelatedBookName(relatedBookName);
        }

        public void InsertBook(BookModel book)
        {
            _mongoDbHelper.InsertBook(book);
        }
    }
}
