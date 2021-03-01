using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentViewModel : BaseViewModel
    {

        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);
                Ticket = _ticketService.GetTicketInfo(value);

                //TODO - Atribuir Data FINAL e Calcular o valor do Ticket
            }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set {
                SetProperty(ref _ticket,value);
            }
        }



        private TicketService _ticketService;

        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();


        }
    }
}
