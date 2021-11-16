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
		public double Amount { get; init; }
		public string Type { get; init; }

		public Transaction(DateTime date, double amount, string type)
		{
			Date = date;
			Amount = amount;
			Type = type;
		}

		public Transaction(string transaction)
		{
			string[] trData = transaction.Split('|');
			trData.ToList().ForEach(s => s = s.Trim());

			Date = Convert.ToDateTime(trData[0]);
			if(trData.Length == 3)Amount = Convert.ToDouble(trData[1]);
			Type = trData[^1];
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

		public BankAccount()
		{
			transactions = new();
		}

		public BankAccount(double balance, List<Transaction> transactions) : this()
		{
			Balance = balance;
			this.transactions = transactions;
		}

		public BankAccount(string[] bankAccountData) : this()
		{
			Balance = Convert.ToDouble(bankAccountData[0]);

			int transactionCount = bankAccountData.Length - 1;
			string[] transactionsData = new string[transactionCount];
			Array.Copy(bankAccountData, 1, transactionsData, 0, transactionCount);

			transactionsData.ToList().ForEach(s => transactions.Add(new Transaction(s)));
		}

		public double CalculateBalance(DateTime date)
		{
			for(int i = 0; i < transactions.Count; i++)
			{
				if(transactions[i].Type == "in")
				{
					Balance += transactions[i].Amount;
				}
				else if(transactions[i].Type == "out")
				{
					Balance -= transactions[i].Amount;
				}
				else if(transactions[i].Type == "revert" && i != 0)
				{

				}
			}

			return Balance;
		}
	}
}
