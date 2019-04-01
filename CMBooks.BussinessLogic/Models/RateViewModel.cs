using System;

namespace CMBooks.BusinessLogic.Models
{
    public class RateViewModel
    {

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public int Rate1 { get; set; }

        public DataLayer.Rate CopyTo()
        {
            return new DataLayer.Rate()
            {
                Id = this.Id,
                UserId = this.UserId,
                BookId = this.BookId,
                Rate1 = this.Rate1
            };
        }
    }
}
