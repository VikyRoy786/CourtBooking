using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.ViewModel
{
    public class GetListRequest
    {
        public string Sort { get; set; }
        public string SortColumn { get; set; }
        public int PerPage { get; set; }
        public int Page { get; set; }
    }
}
