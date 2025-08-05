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
							  .UseInMemoryDatabase("temp_Bongo").Options;
			_dbContext = new ApplicationDbContext(options);
		}
	}
}