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

           var statement =  String.Format("{0, 20} {1, 16} {2, 8} {3, 10} {4, 10} {5, 10} {6, 8}\n\n", "Name", "Account Number", "Type", "Amount", "Balance", "Note", "Date");
            
            foreach(var info in transactionList)
            {

                statement += String.Format("{0, 20} {1, 16} {2, 9} {3, 10} {4, 10} {5, 17} {6, 10}\n\n", info.OwnerName, info.TAccountNumber, info.TAccountType, info.TAmount, info.TBalance, info.Note, info.TransactDate.ToShortDateString());

            }
            
            
            return statement;
        }


    }
}
