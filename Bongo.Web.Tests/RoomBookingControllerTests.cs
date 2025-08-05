using Bongo.Core.Services.IServices;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Bongo.Web.Tests
{
	[TestFixture]
	public class RoomBookingControllerTests
	{
		private Mock<IStudyRoomBookingService> _studyRoomBookingService;
		private RoomBookingController _roomBookingController;

		[SetUp]
		public void ArrangePhase()
		{
			_studyRoomBookingService = new Mock<IStudyRoomBookingService>();
			_roomBookingController = new RoomBookingController(_studyRoomBookingService.Object);
		}

		[Test]
		public void Index_NoInput_OutputIsGetAllBookingInvoked()
		{
			// Arrange

			// Act
			_roomBookingController.Index();

			// Assert
			_studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once);
		}

		[Test]
		public void Book_InputIsDummyRequestWithModelError_OutputIsBookViewReturned()
		{
			// Arrange
			_roomBookingController.ModelState.AddModelError("test", "test");

			// Act
			var result = _roomBookingController.Book(null);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That((result as ViewResult).ViewName, Is.EqualTo("Book"));
		}
	}
}