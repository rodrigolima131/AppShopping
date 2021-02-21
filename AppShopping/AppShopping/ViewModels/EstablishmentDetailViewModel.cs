using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AppShopping.Services;
using System.Linq;

namespace AppShopping.ViewModels
{
    public class EstablishmentDetailViewModel : BaseViewModel
    {
        public Establishment Establishment { get; set; }

        public EstablishmentDetailViewModel()
        {
            Establishment = new EstablishmentService().GetEstablishments().First();
        }

      
        }
 }
