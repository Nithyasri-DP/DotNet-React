using BankApp.Models;
using BankApp.Services;
using Moq;
using NUnit.Framework;

namespace BankServiceTestProject
{
    [TestFixture]
    public class BankServiceTest
    {
        private Mock<IBankRepository> _mockRepo;
        private BankService _bankService;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IBankRepository>();
            _bankService = new BankService(_mockRepo.Object);
        }

        [Test]
        public void When_Deposit_PositiveAmount_Should_UpdateBalance()
        {
            var acc = new Account { AccountNumber = "1234", Balance = 1000 };
            _mockRepo.Setup(r => r.GetAccount("1234")).Returns(acc);

            var newBalance = _bankService.Deposit("1234", 500);

            Assert.That(newBalance, Is.EqualTo(1500));
            _mockRepo.Verify(r => r.UpdateAccount(It.Is<Account>(a => a.Balance == 1500)), Times.Once);
        }

        [Test]
        public void When_Deposit_InvalidAmount_Should_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => _bankService.Deposit("1234", 0));
        }

        [Test]
        public void When_Withdraw_SufficientFunds_Should_UpdateBalance()
        {
            var acc = new Account { AccountNumber = "1234", Balance = 1000 };
            _mockRepo.Setup(r => r.GetAccount("1234")).Returns(acc);

            var newBalance = _bankService.Withdraw("1234", 300);

            Assert.That(newBalance, Is.EqualTo(700));
        }

        [Test]
        public void When_Withdraw_InsufficientFunds_Should_ThrowException()
        {
            var acc = new Account { AccountNumber = "1234", Balance = 100 };
            _mockRepo.Setup(r => r.GetAccount("1234")).Returns(acc);

            Assert.Throws<InvalidOperationException>(() => _bankService.Withdraw("1234", 500));
        }

        [Test]
        public void When_Call_GetAccount_Should_ReturnSameInstance()
        {
            var acc = new Account { AccountNumber = "1234", Balance = 100 };
            _mockRepo.Setup(r => r.GetAccount("1234")).Returns(acc);

            var result = _mockRepo.Object.GetAccount("1234");

            Assert.That(result, Is.SameAs(acc));
        }
    }
}
