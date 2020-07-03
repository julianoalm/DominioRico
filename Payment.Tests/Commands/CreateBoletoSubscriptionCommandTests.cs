using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Commands
{
    public class CreateBoletoSubscriptionCommandTests
    {
        //--------------------------------------
        // Ver metodologia Red, Green, Refactor
        //--------------------------------------

        [TestMethod]
        public void ShouldReturnAnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
        
    }
}
