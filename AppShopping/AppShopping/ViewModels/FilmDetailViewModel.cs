using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppShopping.ViewModels
{
    public class FilmDetailViewModel
    {
        public Film Film { get; set; }

        public FilmDetailViewModel()
        {
            Film = new CinemaService().GetFilms().First();

        }
    }
}
