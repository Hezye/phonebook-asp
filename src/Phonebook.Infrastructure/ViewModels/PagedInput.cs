using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phonebook.Infrastructure.ViewModels
{
    public class PagedInput
    {
        public PagedInput()
        {

        }

        public PagedInput(int pageSize, int? pageIndex = 1)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }


        [Required, Range(1, 1000)]
        public int PageSize { get; set; }

        [Range(1, 100000)]
        public int? PageIndex { get; set; }
    }
}
