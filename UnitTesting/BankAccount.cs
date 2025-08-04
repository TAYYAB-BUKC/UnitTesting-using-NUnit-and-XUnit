using UnitTesting.Services.Interfaces;

namespace UnitTesting
{
	public class BankAccount
	{
		private readonly ILogBook _logBook;
		public decimal Balance { get; set; }

		public BankAccount(ILogBook logBook)
		{
			_logBook = logBook;
			Balance = 0;
		}

		public decimal GetBalance()
		{
			return Balance;
		}

		public bool Deposit(decimal amount)
		{
			_logBook.Log($"Deposit invoked with amount {amount}");
			Balance += amount;
			return true;
		}

		public bool WithDraw(decimal amount)
		{
			if(Balance <= amount)
			{
				_logBook.LogToDatabase($"Withdrawal invoked with amount: {amount}");
				Balance -= amount;
				return _logBook.LogBalanceAfterWithdrawal(Balance);
			}
			return _logBook.LogBalanceAfterWithdrawal(Balance - amount);
		}
	}
}