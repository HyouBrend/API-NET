using System.Collections.Generic;

namespace MoonaHoshinova.Output
{
    public class BookListOutput
    {
        public string Message { get; set; }
        public List<BookOutput> Books { get; set; }
    }

    public class BookOutput
    {
        public string Id { get; set; }
        public string NameBook { get; set; }
        public string AuthorBook { get; set; }
        public string DescriptionBook { get; set; }
        public string CategoryBook { get; set; }
        public List<string> RelatedBookByAuthor { get; set; }
        public string PublisherDateBook { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
