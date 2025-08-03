namespace UnitTesting
{
	public class BankAccount
	{
		public decimal Balance { get; set; }

		public decimal GetBalance()
		{
			return Balance;
		}

		public bool Deposit(decimal amount)
		{
			Balance += amount;
			return true;
		}

		public bool WithDraw(decimal amount)
		{
			if(Balance <= amount)
			{
				Balance -= amount;
				return true;
			}
			return false;
		}
	}
}