using CMBooks.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMBooks.BussinessLogic.Models
{
    public class BookVMPaginationModel
    {
        public int TotalItems { get; set; }

        public int Page { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
