using System;

namespace ExamRetake
{
	class Program
	{
		static void Main(string[] args)
		{
			//create bankAccount
			FileWorker fileWorker = new();
			string[] input = fileWorker.ReadFile("input.txt");
			BankAccount bankAccount = new(input);
			//if (user input is date) currentBalance
			int[] arr;
			//else finalBalance

		}
	}
}
