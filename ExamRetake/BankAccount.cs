using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRetake
{
	public class Transaction
	{
		public DateTime Date { get; init; }
		public double Sum { get; init; }
		public string Type { get; init; }

		public Transaction(DateTime date, double sum, string type)
		{
			Date = date;
			Sum = sum;
			Type = type;
		}

		public Transaction(string transaction)
		{
			string[] trData = transaction.Split('|');
			trData.ToList().ForEach(s => s = s.Trim());

			Date = Convert.ToDateTime(trData[0]);
			Sum = Convert.ToDouble(trData[1]);
			Type = trData[2];
		}
	}

	public class BankAccount
	{
		private List<Transaction> transactions;
		private double balance = 0;
		public double Balance
		{
			get => balance;
			set
			{
				if (balance < 0) throw new ArgumentException("Negative balance");
				else balance = value;
			}
		}

		public BankAccount(double balance, List<Transaction> transactions)
		{
			Balance = balance;
			this.transactions = transactions;
		}

		public BankAccount(string[] bankAccountData)
		{
			Balance = Convert.ToDouble(bankAccountData[0]);

			int transactionCount = bankAccountData.Length - 1;
			string[] transactionsData = new string[transactionCount];
			Array.Copy(bankAccountData, 1, transactionsData, 0, transactionCount);

			transactionsData.ToList().ForEach(s => transactions.Add(new Transaction(s)));
		}

		public double CalculateBalance(DateTime date)
		{
			throw new NotImplementedException();
		}
	}
}
