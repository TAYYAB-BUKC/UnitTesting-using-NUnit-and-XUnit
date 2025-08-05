using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bongo.DataAccess.Tests
{
	[TestFixture]
	public class StudyRoomBookingRepositoryTests
	{
		private StudyRoomBooking studyRoomBooking_One;
		private StudyRoomBooking studyRoomBooking_Two;
		private ApplicationDbContext _dbContext;
		private StudyRoomBookingRepository _studyRoomBookingRepository;
		private DbContextOptions<ApplicationDbContext> DbContextOptions;
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
				BookingId = 2,
				Date = new DateTime(2025, 08, 30),
				FirstName = "Test",
				LastName = "2",
				Email = "test2@test.com",
				StudyRoomId = 2
			};

			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
								   .UseInMemoryDatabase("temp_Bongo").Options;
			
			_dbContext = new ApplicationDbContext(options);
		}

		[Test, Order(1)]
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

		[Test]
		[Order(2)]
		public void GetAllBooking_InputIsBookingOneAndBookingTwo_OutputIsGetTwoBookingsFromTheDatabase()
		{
			//// Arrange
			//List<StudyRoomBooking> expectedResults = new List<StudyRoomBooking>() { studyRoomBooking_One, studyRoomBooking_Two };
			//List<StudyRoomBooking> actualResults = new List<StudyRoomBooking>();

			//// Act
			//using (_dbContext = new ApplicationDbContext(DbContextOptions))
			//{
			//	_dbContext.StudyRoomBookings.Add(studyRoomBooking_One);
			//	_dbContext.StudyRoomBookings.Add(studyRoomBooking_Two);
			//}

			//using (_dbContext = new ApplicationDbContext(DbContextOptions))
			//{
			//	_studyRoomBookingRepository = new StudyRoomBookingRepository(_dbContext);
			//	actualResults = _studyRoomBookingRepository.GetAll(null).ToList();
			//}			

			//// Assert
			//CollectionAssert.AreEqual(expectedResults, actualResults);


			// Arrange
			List<StudyRoomBooking> expectedResults = new List<StudyRoomBooking>() { studyRoomBooking_One, studyRoomBooking_Two };
			List<StudyRoomBooking> actualResults = new List<StudyRoomBooking>();
			_dbContext.Database.EnsureDeleted();
			_studyRoomBookingRepository = new StudyRoomBookingRepository(_dbContext);
			_studyRoomBookingRepository.Book(studyRoomBooking_One);
			_studyRoomBookingRepository.Book(studyRoomBooking_Two);

			// Act
			actualResults = _studyRoomBookingRepository.GetAll(null).ToList();

			// Assert
			CollectionAssert.AreEqual(expectedResults, actualResults, new StudyRoomBookingComparer());
		}
	}
}