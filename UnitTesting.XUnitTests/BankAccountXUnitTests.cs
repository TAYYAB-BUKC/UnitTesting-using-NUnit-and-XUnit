using Moq;
using UnitTesting.Services.Interfaces;
using Xunit;

namespace UnitTesting.XUnitTests
{
	public class BankAccountXUnitTests
	{
		private BankAccount bankAccount;

		public BankAccountXUnitTests()
		{
			//bankAccount = new(new LogBookFaker());
			var moq = new Mock<ILogBook>();
			bankAccount = new(moq.Object);
		}

		[Fact]
		public void Deposit_InputAmountIs100_OutputIsTrue()
		{
			// Arrange

			// Act
			var result = bankAccount.Deposit(100);

			// Assert
			Assert.True(result);
			Assert.Equal(100, bankAccount.GetBalance());
		}

		[Theory]
		[InlineData(200, 100)]
		[InlineData(200, 150)]
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
			Assert.True(result);
		}

		[Theory]
		[InlineData(200, 201)]
		[InlineData(200, 300)]
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
			Assert.False(result);
		}

		[Fact]
		public void LogAndReturnMessage_NoInput_OutputIsMessageItself()
		{
			// Arrange
			string desiredOutput = "Hello";
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.Setup(lb => lb.LogAndReturnMessage(It.IsAny<string>())).Returns((string message) => message);

			// Act
			var result = mockLogBook.Object.LogAndReturnMessage("hello");

			// Assert
			Assert.Equal(desiredOutput.ToLower(), result.ToLower());
		}

		[Fact]
		public void LogAndOutputMessage_InputIsBen_OutputIsHelloBenWithTrue()
		{
			// Arrange
			string finalMessage = "hello";
			string result = string.Empty;
			var mockLogBook = new Mock<ILogBook>();
			mockLogBook.Setup(lb => lb.LogAndOutputMessage(It.IsAny<string>(), out finalMessage)).Returns(true);

			// Act

			// Assert
			Assert.True(mockLogBook.Object.LogAndOutputMessage("Ben", out result));
			Assert.Equal(finalMessage.ToLower(), result.ToLower());
		}

		[Fact]
		public void LogWithRefObject_InputIsRefOfCustomer_OutputIsTrue()
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			Customer customer = new();
			Customer customerNotUsed = new();

			mockLogBook.Setup(lb => lb.LogWithRefObject(ref customer)).Returns(true);

			// Act

			// Assert
			Assert.True(mockLogBook.Object.LogWithRefObject(ref customer));
			Assert.False(mockLogBook.Object.LogWithRefObject(ref customerNotUsed));
		}

		[Fact]
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
			Assert.Equal("Warning", mockLogBook.Object.LogType);
			Assert.Equal(20, mockLogBook.Object.LogSeverity);
		}

		[Fact]
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
			Assert.Equal("Hello, Ben", initialInput);


			Assert.Equal(8, counter);

			mockLogBook.Setup(lb => lb.LogAndReturnMessage(It.IsAny<string>())).Returns("true")
					   .Callback(() =>
					   {
						   counter++;
					   });

			mockLogBook.Object.LogAndReturnMessage("Ben");
			Assert.Equal(9, counter);

			mockLogBook.Object.LogAndReturnMessage("Ben");
			Assert.Equal(10, counter);
		}

		[Fact]
		public void MOQVerification_NoInput_OutputVerification()
		{
			// Arrange
			var mockLogBook = new Mock<ILogBook>();
			bankAccount = new(mockLogBook.Object);

			// Act
			bankAccount.Deposit(100);

			// Assert
			Assert.Equal(100, bankAccount.GetBalance());
			mockLogBook.Verify(lb => lb.Log(It.IsAny<string>()), Times.Exactly(2));
			mockLogBook.Verify(lb => lb.Log("Deposit invoked"), Times.Once);
			mockLogBook.VerifySet(lb => lb.LogSeverity = 101, Times.Once);
			mockLogBook.VerifyGet(lb => lb.LogSeverity, Times.Once);
		}
	}
}