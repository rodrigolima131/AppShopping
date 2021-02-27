using AppShopping.Libraries.Enums;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppShopping.Services
{
    public class TicketService
    {
        private List<Ticket> fakeTickets = new List<Ticket>()
        {
            new Ticket(){Number="109703757667",StartDate = new DateTime(2020,10,20,16,02,32),Status=TicketStatus.paid},
            new Ticket(){Number="209893557324",StartDate = new DateTime(2020,10,20,18,56,22)},
            new Ticket(){Number="359645757789",StartDate = new DateTime(2020,10,20,20,32,01)}
        };

        public Ticket GetTicketInfo(string number) {
            var endDate = new DateTime(2020, 10, 20, 22, 00, 00);

            var ticket = fakeTickets.FirstOrDefault(a => a.Number == number);

            if (ticket == null)
                throw new Exception("Ticket não encontrado!");
            if (ticket.Status == TicketStatus.paid)
                throw new Exception("Ticket já  pago");

            ticket.EndDate = endDate;
            ticket.Price = 6.00m;

            return ticket;
        }
    }
}
