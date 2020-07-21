using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlySite.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public IEnumerable<int> MovieIds { get; set; }
    }
}