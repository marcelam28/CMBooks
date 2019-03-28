using System;

namespace CMBooks.BusinessLogic.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public DataLayer.Book CopyTo()
        {
            return new DataLayer.Book()
            {
                Id = this.Id,
                Title = this.Title,
                Author = this.Author,
                PublicationDate = this.PublicationDate,
                Pages = this.Pages,
                Description = this.Description,
                Genre = this.Genre
            };
        }
    }
}
