using AppShopping.Libraries.Helpers.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketScanCommand { get; set; }

        private string _message;


        public string Message { 
            get {
                return _message;
            } 
            set {
                SetProperty(ref _message, value);
            }
        }

        public ICommand TicketPaidHistoryCommand { get; set; }

        public TicketScanViewModel()
        {
            TicketScanCommand = new Command(TicketScan);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);

        }

        private void TicketScan()
        {

        }
        private void TicketPaidHistory()
        {

        }
    }
}
