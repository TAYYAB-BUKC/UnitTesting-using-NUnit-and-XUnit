using Xunit;

namespace UnitTesting.XUnitTests
{
	public class GradingCalculatorXUnitTests
	{
		private GradingCalculator gradingCalculator;

		public GradingCalculatorXUnitTests()
		{
			gradingCalculator = new();
		}

		[Fact]
		public void GetGrade_InputScoreIs95AndAttendanceIs90_OutputAGrade()
		{
			// Arrange
			gradingCalculator.Score = 95;
			gradingCalculator.AttendancePercentage = 90;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal("A", grade);
		}

		[Fact]
		public void GetGrade_InputScoreIs85AndAttendanceIs90_OutputBGrade()
		{
			// Arrange
			gradingCalculator.Score = 85;
			gradingCalculator.AttendancePercentage = 90;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal("B", grade);
		}

		[Fact]
		public void GetGrade_InputScoreIs65AndAttendanceIs90_OutputCGrade()
		{
			// Arrange
			gradingCalculator.Score = 65;
			gradingCalculator.AttendancePercentage = 90;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal("C", grade);
		}

		[Fact]
		public void GetGrade_InputScoreIs95AndAttendanceIs65_OutputBGrade()
		{
			// Arrange
			gradingCalculator.Score = 95;
			gradingCalculator.AttendancePercentage = 65;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal("B", grade);
		}

		[Theory]
		[InlineData(95, 55)]
		[InlineData(65, 55)]
		[InlineData(50, 90)]
		public void GetGrade_InputScoreAndAttendance_OutputFGrade(int score, int attendance)
		{
			// Arrange
			gradingCalculator.Score = score;
			gradingCalculator.AttendancePercentage = attendance;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal("F", grade);
		}

		[Theory]
		[InlineData(95, 55, "F")]
		[InlineData(65, 55, "F")]
		[InlineData(50, 90, "F")]
		public void GetGrade_InputScoreAndAttendance_OutputFGrade_New(int score, int attendance, string expectedGrade)
		{
			// Arrange
			gradingCalculator.Score = score;
			gradingCalculator.AttendancePercentage = attendance;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal(expectedGrade, grade);
		}

		[Theory]
		[InlineData(95, 90, "A")]
		[InlineData(85, 90, "B")]
		[InlineData(65, 90, "C")]
		[InlineData(95, 65, "B")]
		[InlineData(95, 55, "F")]
		[InlineData(65, 55, "F")]
		[InlineData(50, 90, "F")]
		public void GetGrade_InputScoreAndAttendance_OutputExpectedGrade(int score, int attendance, string expectedGrade)
		{
			// Arrange
			gradingCalculator.Score = score;
			gradingCalculator.AttendancePercentage = attendance;

			// Act
			var grade = gradingCalculator.GetGrade();

			// Assert
			Assert.Equal(expectedGrade, grade);
		}
	}
}