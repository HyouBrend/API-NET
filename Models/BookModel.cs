using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MoonaHoshinova.Models
{
    public class BookModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }

        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("name_book")]
        public string NameBook { get; set; }

        [BsonElement("author_book")]
        public string AuthorBook { get; set; }

        [BsonElement("description_book")]
        public string DescriptionBook { get; set; }

        [BsonElement("category_book")]
        public string CategoryBook { get; set; }

        [BsonElement("related_book_by_author")]
        public RelatedBookByAuthor RelatedBookByAuthor { get; set; }

        [BsonElement("publisher_date_book")]
        public DateTime PublisherDateBook { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class RelatedBookByAuthor
    {
        [BsonElement("name_related_book")]
        public List<string> NameRelatedBook { get; set; }
    }
}
