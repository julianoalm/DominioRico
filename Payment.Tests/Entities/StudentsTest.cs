using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;

        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Juliano", "Martins");
            _document = new Document("05719220666", Domain.Enums.EDocumentType.CPF);
            _email = new Email("julianoalm@gmail.com");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _address = new Address("Sebastiao Malucelli", "580", "Novo Mundo", "PR", "Curitiba", "Brasil", "85050270");
            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Juliano", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            //Tentar incluir a mesma subscription duas vezes, deverá receber um erro pois 
            //uma subscription só é aceita caso não tenha outra ativa.
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {           
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Juliano", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);           

            Assert.IsTrue(_student.Valid);
        }        
    }
}
