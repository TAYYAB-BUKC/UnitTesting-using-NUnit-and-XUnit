using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
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
		private StudyRoomBooking request;
		private List<StudyRoom> availableRooms;

		[SetUp]
		public void ArrangePhase()
		{
			_studyRoomBookingRepository = new Mock<IStudyRoomBookingRepository>();
			_studyRoomRepository = new Mock<IStudyRoomRepository>();

			availableRooms = new List<StudyRoom>()
			{
				new StudyRoom
				{
					Id = 1,
					RoomName = "Michigan",
					RoomNumber = "001"
				}
			};

			_studyRoomRepository.Setup(r => r.GetAll()).Returns(availableRooms);
			studyRoomBookingService = new StudyRoomBookingService(
				_studyRoomBookingRepository.Object,
				_studyRoomRepository.Object
			);

			request = new StudyRoomBooking()
			{
				Date = new DateTime(2025, 08, 20),
				FirstName = "Test",
				LastName = "1",
				Email = "test1@test.com",
			};
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

		[Test]
		public void BookStudyRoom_InputIsNullRequest_OutputIsExceptionThrown()
		{
			// Arrange

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => studyRoomBookingService.BookStudyRoom(null));

			// Extra Check Part 1
			var exception = Assert.Throws<ArgumentNullException>(() => studyRoomBookingService.BookStudyRoom(null));
			Assert.That("Value cannot be null. (Parameter 'request')", Is.EqualTo(exception.Message));

			// Extra Check Part 2
			Assert.That(() => studyRoomBookingService.BookStudyRoom(null), Throws.ArgumentNullException.With.Message.EqualTo("Value cannot be null. (Parameter 'request')"));
		}

		[Test]
		public void BookStudyRoom_InputIsAValidRequest_OutputIsRoomBooked()
		{
			// Arrange
			StudyRoomBooking newBooking = new();
			_studyRoomBookingRepository.Setup(x=>x.Book(It.IsAny<StudyRoomBooking>()))
									   .Callback<StudyRoomBooking>((booking) =>
									   {
										   newBooking = booking;
									   });

			// Act
			studyRoomBookingService.BookStudyRoom(request);

			// Assert
			_studyRoomBookingRepository.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
			Assert.That(newBooking, Is.Not.Null);
			Assert.That(newBooking.FirstName, Is.EqualTo(request.FirstName));
			Assert.That(newBooking.LastName, Is.EqualTo(request.LastName));
			Assert.That(newBooking.Email, Is.EqualTo(request.Email));
			Assert.That(newBooking.Date, Is.EqualTo(request.Date));
			Assert.That(newBooking.StudyRoomId, Is.EqualTo(availableRooms.FirstOrDefault().Id));
			Assert.That(newBooking.StudyRoomId, Is.EqualTo(1));
		}

		[Test]
		public void BookStudyRoom_InputIsAValidRequest_OutputIsResultValuesMatchedWithRequest()
		{
			// Arrange

			// Act
			var result = studyRoomBookingService.BookStudyRoom(request);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.FirstName, Is.EqualTo(request.FirstName));
			Assert.That(result.LastName, Is.EqualTo(request.LastName));
			Assert.That(result.Email, Is.EqualTo(request.Email));
			Assert.That(result.Date, Is.EqualTo(request.Date));
		}
	}
}