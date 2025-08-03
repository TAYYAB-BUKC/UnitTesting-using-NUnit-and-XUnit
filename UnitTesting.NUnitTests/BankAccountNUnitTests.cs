using NUnit.Framework;
using UnitTesting.Services;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class BankAccountNUnitTests
	{
		private BankAccount bankAccount;
		[SetUp]
		public void ArrangeSetup()
		{
			bankAccount = new(new LogBookFaker());
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