using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        //--------------------------------------
        // Ver metodologia Red, Green, Refactor
        //--------------------------------------

        [TestMethod]
        public void ShouldReturnAnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            
            command.FirstName = "Juliano";
            command.LastName = "Martins";
            command.Document = "99999999999";
            command.Email = "julianoalm1@gmail.com";

            command.BarCode = "123456789";
            command.BoletoNumber = "12345";

            command.PaymentNumber = "123456";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Juliano";
            command.PayerDocument = "05719220666";
            command.Type = Domain.Enums.EDocumentType.CPF;
            command.PayerEmail = "julianoalm@gmail.com";
            command.Street = "Sebastião Malucelli";
            command.Number = "580";
            command.Neighborhood = "Novo Mundo";
            command.City = "Curitiba";
            command.State = "PR";
            command.Country = "Brasil";
            command.ZipCode = "85050270";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}
