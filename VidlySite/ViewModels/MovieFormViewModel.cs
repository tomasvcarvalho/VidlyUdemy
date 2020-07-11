using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlySite.Models;

namespace VidlySite.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
    }
}