using System;

namespace CMBooks.BusinessLogic.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public string Comment1 { get; set; }

        public DataLayer.Comment CopyTo()
        {
            
            return new DataLayer.Comment()
            {
                Id = this.Id,
                UserId = this.UserId,
                BookId = this.BookId,
                Comment1 = this.Comment1
            };
        }
    }
}
