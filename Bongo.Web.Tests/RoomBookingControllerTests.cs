using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
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

		[Test]
		public void Book_InputIsDummyRequestWithNoRoomAvailable_OutputIsViewDataError()
		{
			// Arrange
			_studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
									.Returns(new StudyRoomBookingResult()
									{
										Code = StudyRoomBookingCode.NoRoomAvailable
									});

			// Act
			var result = _roomBookingController.Book(null);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.InstanceOf<ViewResult>());
			Assert.That((result as ViewResult).ViewData["Error"], Is.EqualTo("No Study Room available for selected date"));
		}

		[Test]
		public void Book_InputIsAValidRequestWithRoomAvailability_OutputIsSuccessCodeWithRedirectToActionResult()
		{
			// Arrange
			_studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
									.Returns((StudyRoomBooking booking) => new StudyRoomBookingResult()
									{
										Code = StudyRoomBookingCode.Success,
										FirstName = booking.FirstName,
										LastName = booking.LastName,
										Date = booking.Date,
										Email = booking.Email,
									});

			// Act
			var result = _roomBookingController.Book(new StudyRoomBooking()
			{
				Date = new DateTime(2025, 08, 20),
				FirstName = "Test",
				LastName = "1",
				Email = "test1@test.com",
			});

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
			var actionResult = result as RedirectToActionResult;
			Assert.That(actionResult.RouteValues["FirstName"], Is.EqualTo("Test"));
			Assert.That(actionResult.RouteValues["LastName"], Is.EqualTo("1"));
			Assert.That(actionResult.RouteValues["Email"], Is.EqualTo("test1@test.com"));
			Assert.That(actionResult.RouteValues["Date"], Is.EqualTo(new DateTime(2025, 08, 20)));
		}
	}
}