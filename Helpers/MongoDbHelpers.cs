using MongoDB.Driver;
using MongoDB.Driver.Linq; // Tambahkan namespace ini untuk menggunakan LINQ dengan MongoDB
using MoonaHoshinova.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonaHoshinova.Helper
{
    public class MongoDbHelper
    {
        private readonly IMongoCollection<BookModel> _bookCollection;

        public MongoDbHelper(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            _bookCollection = database.GetCollection<BookModel>("Suisei Hoshimachi");
        }

        public List<BookModel> GetAllBooks()
        {
            return _bookCollection.AsQueryable().ToList();
        }

        public List<BookModel> SearchByRelatedBookName(string relatedBookName)
        {
            return _bookCollection.AsQueryable()
                                  .Where(book => book.RelatedBookByAuthor.NameRelatedBook.Contains(relatedBookName))
                                  .ToList();
        }

        public void InsertBook(BookModel book)
        {
            _bookCollection.InsertOne(book);
        }
    }
}
