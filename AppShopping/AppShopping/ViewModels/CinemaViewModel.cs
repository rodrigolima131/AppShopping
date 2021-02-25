using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.ViewModels
{
    public class CinemaViewModel :BaseViewModel
    {
        public  List<Film> Films { get; set; }

        public CinemaViewModel()
        {
            Films = new CinemaService().GetFilms();
        }
    }
}
