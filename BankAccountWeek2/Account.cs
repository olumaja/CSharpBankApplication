using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class Account
    {
        private static int _generateAccountNumber = 1000000001;
        public string AccountNumber { get; }
        public string Owner { get; }
        public string AccountType { get; }

        protected List<Transaction> transactionList = new List<Transaction>();

        public decimal Balance
        {
            
        get
            {
                decimal balance = 0;
                foreach (var item in transactionList)
                {
                    balance += item.TAmount;
                }
                return balance;
            }

        }

        



        public Account(string name, string accountType)
        {
            this.AccountNumber = _generateAccountNumber.ToString();
            _generateAccountNumber++;
           this. Owner = name;
            this.AccountType = accountType;

            
        }

        public string AccountStatememt()
        {
            var statement = new StringBuilder();
            statement.AppendLine("\tName\t\tAccount Number\t\tType\t\tAmount\t\tBalance\t\tNote\t\tDate");

            foreach (var info in transactionList)
            {

                statement.AppendLine($"{info.OwnerName}\t{info.TAccountNumber}\t\t{info.TAccountType}\t\t{info.TAmount}\t\t{info.TBalance}\t{info.Note}\t\t{info.TransactDate.ToShortDateString()}");
            }
            return statement.ToString();
        }



        //public decimal Balance
        //{
        //    get
        //    {
        //        decimal balance = 0;
        //        foreach (var item in transactionList)
        //        {
        //            balance += item.Amount;
        //        }
        //        return balance;
        //    }
        //}





        //public void Deposit(decimal amount, string remark, DateTime depositDate)
        //{
        //    if(amount < 1)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(amount), "You cannot deposit negative amount");
        //    }
        //    var deposit = new Transaction(amount, remark, DateTime.Now);
        //    transactionList.Add(deposit);

        //}

        //public void Withdrawal(decimal amount, string remark, DateTime withdrawalDate)
        //{
        //    if(amount < 1)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(amount), "You cannot withdraw a negative amount");
        //    }
        //    if(Balance - amount < 0)
        //    {
        //        throw new InvalidOperationException("Not sufficient funds");
        //    }
        //    var deposit = new Transaction(amount, remark, DateTime.Now);
        //    transactionList.Add(deposit);

        //}

    }
}
