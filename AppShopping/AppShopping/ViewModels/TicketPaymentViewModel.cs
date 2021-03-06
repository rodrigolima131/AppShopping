using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Libraries.Validators;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _messages;

        public string Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }


        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);
                Ticket = _ticketService.GetTicketInfo(value);
            }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set
            {
                SetProperty(ref _ticket, value);
            }
        }

        private CreditCard _creditCard;

        public CreditCard CreditCard
        {
            get { return _creditCard; }
            set
            {
                SetProperty(ref _creditCard, value);
            }
        }


        public ICommand PaymentCommand { get; set; }

        private TicketService _ticketService;
        private PaymentService _paymenteService;


        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
            PaymentCommand = new Command(Payment);
            _paymenteService = new PaymentService();
            CreditCard = new CreditCard();
        }

        private void Payment()
        {
            //TODO Validar Manuel, Data Annotation, Fluent Validation

            try
            {
                Messages = string.Empty;
                string messages = Valid(CreditCard);
                if (string.IsNullOrEmpty(messages))
                {
                    string transactionID = _paymenteService.SendPayment(CreditCard,Ticket);
                    Ticket.TransactionID = transactionID;
                    Ticket.Status = Libraries.Enums.TicketStatus.paid;
                    //TODO salvar no banco de dados;
                    var x = _ticketService.GetTicketsPaid();


                }
                else
                {
                    messages = messages;
                }

                //TODO - Redirecionar para tela de suceso
            }
            catch (Exception e)
            {
                // Redirecionar para tela de erro
            }

            //TODO Implementar
            //TODO - VALIDAR
            //TODO - Integrar com api de pagamento

        }

        private string Valid(CreditCard creditCard)
        {

            StringBuilder messages = new StringBuilder();

            if (string.IsNullOrEmpty(creditCard.Name))
            {
                messages.Append("O nome não foi preenchido!" + Environment.NewLine);

            }

            if (string.IsNullOrEmpty(creditCard.Number))
            {

                messages.Append("O Cartão de crédito não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Number.Length < 19)
            {

                messages.Append("O numero do cartão de crédito esta incompleto" + Environment.NewLine);
            }

            try
            {
                var expiredString = creditCard.DateExpired.Split('/');
                var month = int.Parse(expiredString[0]);
                var year = int.Parse(expiredString[1]);
                new DateTime(month, year, 01);

            }
            catch (Exception e)
            {
                messages.Append("A validade do cartão não é valida!" + Environment.NewLine);
            }
            if (string.IsNullOrEmpty(creditCard.SecurityCode))
            {
                messages.Append("O código de segurança não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Number.Length < 3)
            {
                messages.Append("O código de segurança esta incompleto" + Environment.NewLine);

            }

            if (string.IsNullOrEmpty(creditCard.Document))
            {
                messages.Append("O cpf não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Document.Length < 11)
            {
                messages.Append("O cpf esta incompleto" + Environment.NewLine);

            }
            else if (CPFValidator.IsCpf(creditCard.Document))
            {
                messages.Append("O cpf é inválido" + Environment.NewLine);

            }

            return messages.ToString();
        }


    }

}
