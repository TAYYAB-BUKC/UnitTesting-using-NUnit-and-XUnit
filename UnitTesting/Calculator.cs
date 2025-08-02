namespace UnitTesting
{
	public class Calculator
    {
		public List<int> Numbers { get; set; }
        
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

		public List<int> GetOddNumbersFromRange(int min, int max)
		{
			Numbers = new List<int>();
			for (int i = min; i <= max; i++)
			{
				if(!(i % 2 == 0))
				{
					Numbers.Add(i);
				}
			}
			return Numbers;
		}
	}
}