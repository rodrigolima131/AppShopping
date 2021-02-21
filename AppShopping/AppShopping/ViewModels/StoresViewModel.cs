using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppShopping.Libraries.Enums;
using System.ComponentModel;
using AppShopping.Libraries.Helpers.MVVM;

namespace AppShopping.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {

        public String SearchWord { get; set; }

        public ICommand SearchCommand { get; set; }



        private List<Establishment> _establishiment;
        public List<Establishment> Establishments { 
            get {
                return _establishiment;
            }
            set {
                SetProperty(ref _establishiment, value);
            }
        }

        private List<Establishment> _allEstablishments;

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);

            var allEstablishment = new EstablishmentService().GetEstablishments();

            var allStores = allEstablishment.Where(a => a.Type == EstablishmentType.Store).ToList();
            Establishments = allStores;
            _allEstablishments = allStores;

        }

        private void Search()
        {
            //TODO - Lógica de filtrar a lista de lojas.
           Establishments =  _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
    }
}
