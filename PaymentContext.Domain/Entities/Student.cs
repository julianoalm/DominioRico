using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Adress { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            // ----------------------------------------------
            //Pode escolher entre essa e...
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você jpa tem uma assinatura ativa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payments","Esta assinatura não possue pagamentos")
            );

            // e essa alternativa        
            //if (hasSubscriptionActive)
            //    AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
            // ----------------------------------------------

            ////Se já tiver uma assinatura ativa, cancela
            ////...
            ////...

            ////Cancela todas as outras assinaturas, e coloca esta como principal
            //foreach (var sub in Subscriptions)
            //{
            //    sub.Deactivate();
            //}

            //_subscriptions.Add(subscription);
        }
    }
}
