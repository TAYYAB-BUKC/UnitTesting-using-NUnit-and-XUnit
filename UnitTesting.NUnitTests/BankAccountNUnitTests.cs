using Moq;
using NUnit.Framework;
using UnitTesting.Services.Interfaces;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class BankAccountNUnitTests
	{
		private BankAccount bankAccount;
		[SetUp]
		public void ArrangeSetup()
		{
			//bankAccount = new(new LogBookFaker());
			var moq = new Mock<ILogBook>();
			bankAccount = new(moq.Object);
		}

		[Test]
		public void Deposit_InputAmountIs100_OutputIsTrue()
		{
			// Arrange

			// Act
			var result = bankAccount.Deposit(100);

			// Assert
			Assert.That(result, Is.True);
			Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
		}

		[Test]
		[TestCase(200, 100)]
		[TestCase(200, 150)]
		[TestCase(200, 300)]
		public void WithDraw_InputWithDraw100With200Balace_OutputIsTrue(int balance, int withdrawalAmount)
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.Setup(lb => lb.LogToDatabase(It.IsAny<string>())).Returns(true);
			mockLogBook.Setup(lb => lb.LogBalanceAfterWithdrawal(It.Is<decimal>(c => c > 0))).Returns(true);
			bankAccount = new(mockLogBook.Object);
			bankAccount.Balance = balance;

			// Act
			var result = bankAccount.WithDraw(withdrawalAmount);

			// Assert
			Assert.That(result, Is.True);
		}

		[Test]
		[TestCase(200, 201)]
		[TestCase(200, 300)]
		public void WithDraw_InputWithDrawAndBalace_OutputIsFalse(int balance, int withdrawalAmount)
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.Setup(lb => lb.LogToDatabase(It.IsAny<string>())).Returns(true);
			mockLogBook.Setup(lb => lb.LogBalanceAfterWithdrawal(It.Is<decimal>(c => c > 0))).Returns(true);
			//mockLogBook.Setup(lb => lb.LogBalanceAfterWithdrawal(It.Is<decimal>(c => c < 0))).Returns(false);
			mockLogBook.Setup(lb => lb.LogBalanceAfterWithdrawal(It.IsInRange<decimal>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
			bankAccount = new(mockLogBook.Object);
			bankAccount.Balance = balance;

			// Act
			var result = bankAccount.WithDraw(withdrawalAmount);

			// Assert
			Assert.That(result, Is.False);
		}
	}
}