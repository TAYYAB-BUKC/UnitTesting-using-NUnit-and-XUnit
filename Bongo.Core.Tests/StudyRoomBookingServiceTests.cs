using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Moq;
using NUnit.Framework;

namespace Bongo.Core.Tests
{
	[TestFixture]
	public class StudyRoomBookingServiceTests
	{
		private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepository;
		private Mock<IStudyRoomRepository> _studyRoomRepository;
		private StudyRoomBookingService studyRoomBookingService;

		[SetUp]
		public void ArrangePhase()
		{
			_studyRoomBookingRepository = new Mock<IStudyRoomBookingRepository>();
			_studyRoomRepository = new Mock<IStudyRoomRepository>();
			studyRoomBookingService = new StudyRoomBookingService(
				_studyRoomBookingRepository.Object,
				_studyRoomRepository.Object
			);
		}

		[Test]
		public void GetAllBooking_NoInput_OutputIsMethodCalled()
		{
			// Arrange

			// Act
			studyRoomBookingService.GetAllBooking();

			// Assert
			_studyRoomBookingRepository.Verify(r => r.GetAll(null), Times.Once);
		}
	}
}