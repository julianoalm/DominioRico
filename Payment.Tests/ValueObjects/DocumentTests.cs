using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //--------------------------------------
        // Ver metodologia Red, Green, Refactor
        //--------------------------------------

        [TestMethod]
        public void ShouldReturnAnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", Domain.Enums.EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("12345678901234", Domain.Enums.EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnAnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", Domain.Enums.EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataRow("05719220666")]
        [DataRow("12345678901")]
        [DataRow("09876543211")]
        [DataRow("12324567890")]
        [DataRow("34562278999")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, Domain.Enums.EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
