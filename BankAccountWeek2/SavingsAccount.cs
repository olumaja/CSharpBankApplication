using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class SavingsAccount : Account
    {

        private readonly decimal minimumBalance = 100;
        private readonly decimal leastAmount = 1;

        public SavingsAccount(string name, decimal initialDeposit, string accountType)
            : base(name, accountType)
        {
            if(initialDeposit < minimumBalance)
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
            var deposit = new Transaction(Owner, AccountNumber, AccountType, amount, Balance + amount, remark, DateTime.Now);
            transactionList.Add(deposit);

        }

        public void Withdrawal(decimal amount, string remark, DateTime withdrawalDate)
        {
            if (amount < leastAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "You cannot withdraw zero or negative amount");
            }
            if (Balance - amount < minimumBalance)
            {
                throw new InvalidOperationException($"Not sufficient funds; You must have minimum balance of #{minimumBalance}:00");
            }
            var deposit = new Transaction(Owner, AccountNumber, AccountType, -amount, Balance - amount, remark, DateTime.Now);
            transactionList.Add(deposit);

        }

    }
}
