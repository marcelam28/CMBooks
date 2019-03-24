using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.BusinessLogic.Models
{
    public class BaseEntityContainer
    {
        public BaseEntityContainer()
        {
            TotalPages = CurrentPage = ActiveIndex = 0;
        }

        public BaseEntityContainer(int status)
        {
            TotalPages = ActiveIndex = CurrentPage = 0;
        }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int ActiveIndex { get; set; }

        public int TotalElementsCount { get; set; }
    }
}
