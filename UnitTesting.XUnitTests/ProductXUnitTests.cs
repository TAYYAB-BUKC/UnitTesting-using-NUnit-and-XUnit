using Moq;
using UnitTesting.Services.Interfaces;
using Xunit;

namespace UnitTesting.XUnitTests
{
	public class ProductXUnitTests
	{
		private Product product;

		public ProductXUnitTests()
		{
			// Arrange
			product = new Product() { Id = 1, Name = "Product 1", Price = 50 };
		}

		[Fact]
		public void GetProductPrice_InputPlatinumCustomer_OutputPriceWith80PercentDiscount()
		{
			// Arrange

			// Act
			var result = product.GetPrice(new Customer() { OrderTotal = 110 });

			// Assert
			Assert.Equal(40, result);
		}

		[Fact]
		public void GetProductPriceWithMOQAbuse_InputPlatinumCustomer_OutputPriceWith80PercentDiscount()
		{
			// Arrange
			var moq = new Mock<ICustomer>();
			moq.Setup(m => m.OrderTotal).Returns(110);

			// Act
			var result = product.GetPrice(moq.Object);

			// Assert
			Assert.Equal(40, result);
		}
	}
}