using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRetake
{
	public class Transaction
	{
		public double Sum { get; init; }
		public DateTime Date { get; init; }
		public string Type { get; init; }

		public Transaction(double sum, DateTime date, string type)
		{
			Sum = sum;
			Date = date;
			Type = type;
		}
	}

	public class BankAccount
	{
		private List<Transaction> transactions;
		public double Balance { get; private set; }

		public BankAccount()
		{

		}

		public double CalculateBalance(DateTime date)
		{
			throw new NotImplementedException();
		}
	}
}
