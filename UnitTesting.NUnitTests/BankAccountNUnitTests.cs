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
	}
}