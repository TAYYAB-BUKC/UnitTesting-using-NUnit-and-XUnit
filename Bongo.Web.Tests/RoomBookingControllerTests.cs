using Bongo.Core.Services.IServices;
using Bongo.Web.Controllers;
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
	}
}