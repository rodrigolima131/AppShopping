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
        private static List<Ticket> fakeTickets = new List<Ticket>()
        {
            new Ticket(){Number="109703757667",StartDate = new DateTime(2020,10,20,16,02,32),EndDate = new DateTime(2020,10,20,18,02,32),Price=6.20m,Status=TicketStatus.paid},
            new Ticket(){Number="109703757669",StartDate = new DateTime(2020,10,20,14,02,32),EndDate = new DateTime(2020,10,20,17,02,32),Price=12.20m,Status=TicketStatus.paid},
            new Ticket(){Number="209893557324",StartDate = new DateTime(2020,10,20,18,56,22)},
            new Ticket(){Number="359645757789",StartDate = new DateTime(2021,02,28,20,32,01)}
        };

        public List<Ticket> GetTicketsPaid()
        {
            return fakeTickets.Where(a => a.Status == TicketStatus.paid).ToList();
        }
        public Ticket GetTicketInfo(string number) {
            var endDate = DateTime.Now;

            var ticket = fakeTickets.FirstOrDefault(a => a.Number == number);

            if (ticket == null)
                throw new Exception("Ticket não encontrado!");
            if (ticket.Status == TicketStatus.paid)
                throw new Exception("Ticket já  pago");

            ticket.EndDate = endDate;

            ticket.Price = Convert.ToDecimal( PriceCalculator(ticket));

            return ticket;
        }


        public void UpdateTicket(Ticket newTicket)
        {

            var oldticket = fakeTickets.FirstOrDefault(a => a.Number == newTicket.Number);

            oldticket.TransactionID = newTicket.TransactionID;
            oldticket.Price = newTicket.Price;
            oldticket.Status = newTicket.Status;
            oldticket.EndDate = newTicket.EndDate;

        }
        private double PriceCalculator(Ticket ticket)
        {
            TimeSpan dif = ticket.EndDate.Value - ticket.StartDate;
           return Math.Round(dif.TotalMinutes * 0.3);

        }
    }
}
