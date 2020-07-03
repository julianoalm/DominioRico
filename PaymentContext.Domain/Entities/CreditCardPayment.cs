using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, 
            string cardNumber, 
            string lastTansactionNumber, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            string payer,
            Document document,
            Address adress,
            Email email) : base(paidDate, expireDate, total, totalPaid, payer, document, adress, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTansactionNumber = lastTansactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTansactionNumber { get; private set; }
    }
}
