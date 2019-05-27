using System;

namespace CMBooks.BusinessLogic.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Comment1 { get; set; }

        public DateTime AddedAt { get; set; }

        public bool Status { get; set; }
    }
}
