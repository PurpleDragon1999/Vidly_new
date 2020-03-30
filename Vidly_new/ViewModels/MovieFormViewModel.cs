using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_new.Models;

namespace Vidly_new.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<GenreTypes> Genre { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}