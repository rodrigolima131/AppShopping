using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AppShopping.Services;
using System.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace AppShopping.ViewModels
{
    [QueryProperty("establishmentSerialized", "establishmentSerialized")]
    public class EstablishmentDetailViewModel : BaseViewModel
    {
        public Establishment Establishment { get; set; }
        public String establishmentSerialized { 
            set {
                Establishment = JsonConvert.DeserializeObject<Establishment>(Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Establishment));
           } 
        }
        public EstablishmentDetailViewModel()
        {
           // Establishment = new EstablishmentService().GetEstablishments().First();

        }

      
        }
 }
