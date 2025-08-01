using System;

namespace UnitTesting
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
		}

		public double Add(double a, double b)
		{
			return a + b;
		}

		public bool IsOddNumber(int a)
		{
			return !(a % 2 == 0);
		}
	}
}