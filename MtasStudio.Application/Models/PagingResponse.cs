using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Models
{
    public class PagingResponse
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public SortingResponse? SortingResponse { get; set; } = null;


    }
    public class SortingResponse
    {
        public string PropertyName { get; set; }
        public bool IsAscending { get; set; }
    }
}
