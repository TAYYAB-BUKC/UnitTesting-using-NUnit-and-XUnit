using Bongo.Models.Model;
using System.Collections;

namespace Bongo.DataAccess.Tests
{
	public class StudyRoomBookingComparer : IComparer
	{
		public int Compare(object? x, object? y)
		{
			var a = x as StudyRoomBooking;
			var b = y as StudyRoomBooking;

			if (a == null || b == null) return -1;

			return a.BookingId == b.BookingId &&
				   a.FirstName == b.FirstName &&
				   a.LastName == b.LastName &&
				   a.Email == b.Email &&
				   a.Date == b.Date
				   ? 0 : -1;
		}
	}
}