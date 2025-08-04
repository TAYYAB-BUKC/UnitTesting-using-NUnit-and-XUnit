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

		[Test]
		public void LogAndReturnMessage_NoInput_OutputIsMessageItself()
		{
			// Arrange
			string desiredOutput = "Hello";
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.Setup(lb => lb.LogAndReturnMessage(It.IsAny<string>())).Returns((string message) => message);

			// Act
			var result = mockLogBook.Object.LogAndReturnMessage("hello");

			// Assert
			Assert.That(result, Is.EqualTo(desiredOutput).IgnoreCase);
		}

		[Test]
		public void LogAndOutputMessage_InputIsBen_OutputIsHelloBenWithTrue()
		{
			// Arrange
			string finalMessage = "hello";
			string result = string.Empty;
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.Setup(lb => lb.LogAndOutputMessage(It.IsAny<string>(), out finalMessage)).Returns(true);

			// Act

			// Assert
			Assert.That(mockLogBook.Object.LogAndOutputMessage("Ben", out result), Is.True);
			Assert.That(result, Is.EqualTo(finalMessage).IgnoreCase);
		}

		[Test]
		public void LogWithRefObject_InputIsRefOfCustomer_OutputIsTrue()
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			Customer customer = new();
			Customer customerNotUsed = new();

			mockLogBook.Setup(lb => lb.LogWithRefObject(ref customer)).Returns(true);

			// Act

			// Assert
			Assert.That(mockLogBook.Object.LogWithRefObject(ref customer), Is.True);
			Assert.That(mockLogBook.Object.LogWithRefObject(ref customerNotUsed), Is.False);
		}

		[Test]
		public void LogSeverityAndLogType_InputIsSetProperties_OutputIsSettedProperties()
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.SetupAllProperties();
			//mockLogBook.Setup(lb => lb.LogSeverity).Returns(15);
			//mockLogBook.Setup(lb => lb.LogType).Returns("Warning");
			mockLogBook.Object.LogSeverity = 20;
			mockLogBook.Object.LogType = "Warning";

			// Act

			// Assert
			Assert.That(mockLogBook.Object.LogType, Is.EqualTo("Warning"));
			Assert.That(mockLogBook.Object.LogSeverity, Is.EqualTo(20));
		}

		[Test]
		public void MOQCallback_NoInput_ImplementedOutput()
		{
			// Arrange
			string initialInput = "Hello,";
			int counter = 8;
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.SetupAllProperties();
			//mockLogBook.Setup(lb => lb.LogSeverity).Returns(15);
			//mockLogBook.Setup(lb => lb.LogType).Returns("Warning");
			mockLogBook.Setup(lb => lb.LogToDatabase(It.IsAny<string>())).Returns(true)
					   .Callback((string input) =>
					   {
						   initialInput += $" {input}";
					   });

			// Act
			mockLogBook.Object.LogToDatabase("Ben");

			// Assert
			Assert.That(initialInput, Is.EqualTo("Hello, Ben"));


			Assert.That(counter, Is.EqualTo(8));

			mockLogBook.Setup(lb => lb.LogAndReturnMessage(It.IsAny<string>())).Returns("true")
					   .Callback(() =>
					   {
						   counter++;
					   });

			mockLogBook.Object.LogAndReturnMessage("Ben");
			Assert.That(counter, Is.EqualTo(9));

			mockLogBook.Object.LogAndReturnMessage("Ben");
			Assert.That(counter, Is.EqualTo(10));
		}

		[Test]
		public void MOQVerification_NoInput_OutputVerification()
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			bankAccount = new(mockLogBook.Object);

			// Act
			bankAccount.Deposit(100);

			// Assert
			Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
			mockLogBook.Verify(lb => lb.Log(It.IsAny<string>()), Times.Exactly(2));
			mockLogBook.Verify(lb => lb.Log("Deposit invoked"), Times.Once);
			mockLogBook.VerifySet(lb => lb.LogSeverity = 101, Times.Once);
			mockLogBook.VerifyGet(lb => lb.LogSeverity, Times.Once);
		}
	}
}