using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class CurrentAccount : Account
    {

        private readonly decimal minimumBalance = 1000;
        private readonly decimal leastAmount = 1;

        public CurrentAccount(string name, decimal initialDeposit, string accountType)
            : base(name, accountType)
        {
            if (initialDeposit < minimumBalance)
            {
                throw new InvalidOperationException($"The minimum opening balance is #{minimumBalance}:00");
            }
            Deposit(initialDeposit, "Opening balance", DateTime.Now);
        }


        public void Deposit(decimal amount, string remark, DateTime depositDate)
        {
            if (amount < leastAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You cannot deposit zero or negative amount");
            }
            var deposit = new Transaction(Owner, AccountNumber, AccountType, amount, Balance + amount, remark, depositDate);
            transactionList.Add(deposit);

        }

        public void Withdrawal(decimal amount, string remark, DateTime withdrawalDate)
        {
            if (amount < leastAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You cannot withdraw zero or negative amount");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds");
            }
            var deposit = new Transaction(Owner, AccountNumber, AccountType, -amount, Balance - amount, remark, withdrawalDate);
            transactionList.Add(deposit);

        }

        public decimal Transfer(decimal amount, string remark, DateTime transferDate)
        {

            var transferSuccessful = false;
            try
            {
                Withdrawal(amount, remark, transferDate);
                transferSuccessful = true;
            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine(e.Message);
                
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            if (transferSuccessful) 
            {
                Console.WriteLine("Transfer successful");
                return amount; 
            }
            return 0;

        }


    }
}
