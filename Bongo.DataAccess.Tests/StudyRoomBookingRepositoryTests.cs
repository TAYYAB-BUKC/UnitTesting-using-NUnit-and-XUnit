using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bongo.DataAccess.Tests
{
	[TestFixture]
	public class StudyRoomBookingRepositoryTests
	{
		private StudyRoomBooking studyRoomBooking_One;
		private StudyRoomBooking studyRoomBooking_Two;
		private ApplicationDbContext _dbContext;
		private StudyRoomBookingRepository _studyRoomBookingRepository;

		[SetUp]
		public void ArrangePhase()
		{
			studyRoomBooking_One = new StudyRoomBooking()
			{
				BookingId = 1,
				Date = new DateTime(2025, 08, 20),
				FirstName = "Test",
				LastName = "1",
				Email = "test1@test.com",
				StudyRoomId = 1
			};

			studyRoomBooking_Two = new StudyRoomBooking()
			{
				BookingId = 1,
				Date = new DateTime(2025, 08, 30),
				FirstName = "Test",
				LastName = "2",
				Email = "test2@test.com",
				StudyRoomId = 2
			};

			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
							  .UseInMemoryDatabase("temp_Bongo132").Options;
			
			_dbContext = new ApplicationDbContext(options);
		}

		[Test]
		public void SaveBooking_InputIsBookingOne_OutputIsBookingAddedToDB()
		{
			// Arrange
			_studyRoomBookingRepository = new StudyRoomBookingRepository(_dbContext);

			// Act
			_studyRoomBookingRepository.Book(studyRoomBooking_One);
			var bookingFromDatabase = _dbContext.StudyRoomBookings.Find(1);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(bookingFromDatabase.BookingId, Is.EqualTo(studyRoomBooking_One.BookingId));
				Assert.That(bookingFromDatabase.Date, Is.EqualTo(studyRoomBooking_One.Date));
				Assert.That(bookingFromDatabase.FirstName, Is.EqualTo(studyRoomBooking_One.FirstName));
				Assert.That(bookingFromDatabase.LastName, Is.EqualTo(studyRoomBooking_One.LastName));
				Assert.That(bookingFromDatabase.Email, Is.EqualTo(studyRoomBooking_One.Email));
			});
		}
	}
}