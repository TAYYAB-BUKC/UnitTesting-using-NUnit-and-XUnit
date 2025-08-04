using Moq;
using NUnit.Framework;
using UnitTesting.Services.Interfaces;

namespace UnitTesting.NUnitTests
{
	[TestFixture]
	public class ProductNUnitTests
	{
		private Product product;

		[SetUp]
		public void ArrangeSetup()
		{
			// Arrange
			product = new Product() { Id = 1, Name = "Product 1", Price = 50 };
		}

		[Test]
		public void GetProductPrice_InputPlatinumCustomer_OutputPriceWith80PercentDiscount()
		{
			// Arrange

			// Act
			var result = product.GetPrice(new Customer() { OrderTotal = 110 });

			// Assert
			Assert.That(result, Is.EqualTo(40));
		}

		[Test]
		public void GetProductPriceWithMOQAbuse_InputPlatinumCustomer_OutputPriceWith80PercentDiscount()
		{
			// Arrange
			var moq = new Mock<ICustomer>();
			moq.Setup(m => m.OrderTotal).Returns(110);

			// Act
			var result = product.GetPrice(moq.Object);

			// Assert
			Assert.That(result, Is.EqualTo(40));
		}
	}
}