using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class Transaction
    {

        public string OwnerName { get; }
        public decimal TAmount { get; }
        public decimal TBalance { get; }
        public string TAccountNumber { get; }
        public string TAccountType { get; }
        public string Note { get; }
        public DateTime TransactDate { get; }

        public Transaction(string name, string accountNumber, string accountType, decimal money, decimal balance, string remark, DateTime date)
        {

            this.OwnerName = name;
            this.TAccountNumber = accountNumber;
            this.TAccountType = accountType;
            this.TAmount = money;
            this.TBalance = balance;
            this.Note = remark;
            this.TransactDate = date;
        }

    }
}
