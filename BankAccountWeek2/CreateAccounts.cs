using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountWeek2
{
    class CreateAccounts
    {

        private string userMoney;
        private string customerResponse;
        private string accountType;
        private string ownerName;
        private List<string> bankAccountList = new List<string>();
        decimal transferReceiverBalance = 0;

        public CreateAccounts(string fullName)
        {
            ownerName = fullName;
            Console.Write("Enter account type (enter Current or Savings Account): ");
            accountType = Console.ReadLine();

            AccountCreated();
        }

        public void AccountCreated()
        {
            if (String.IsNullOrWhiteSpace(accountType))
            {
                throw new NullReferenceException("Account type cannot be empty");
            }
            else if (accountType.Trim().ToLower() == "current account" || accountType.Trim().ToLower() == "current")
            {
                
                CreateCurrentAccount();
            }
            else if(accountType.Trim().ToLower() == "savings account" || accountType.Trim().ToLower() == "savings")
            {
                
                CreateSavingsAccount();
            }

        }

        //Create current account
        public void CreateCurrentAccount()
        {           
            
            var currentAccountList = new List<CurrentAccount>();
            Console.Write("Enter the initial opening balance minimum of #1,000:00 : ");
            userMoney = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(userMoney))
            {
                Console.WriteLine("Opening balance cannot be empty");
            }
            else
            {

               try
               {
                  var personCurrentAccount = new CurrentAccount(ownerName, Convert.ToDecimal(userMoney), accountType);
                  Console.WriteLine(personCurrentAccount.AccountStatememt());

                  do
                  {
                    Console.WriteLine("To perform transaction");
                    Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money, \"T\" to transfer or \"Q\" to terminate this transaction: ");
                    customerResponse = Console.ReadLine();
                    if (customerResponse.ToLower() == "d")
                    {

                        //Perform money deposit
                       Console.Write("Enter amount to deposit: ");
                       userMoney = Console.ReadLine();
                       Console.Write("Enter remark, necessary for transaction success: ");
                       var remark = Console.ReadLine();
                       Console.WriteLine();
                       if (!String.IsNullOrWhiteSpace(remark))
                       {
                          personCurrentAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                    
                       }
                       else { Console.WriteLine("Transaction fail, try again"); }
                    }
                    else if (customerResponse.ToLower() == "w")
                    {
                       
                       //Perform money withdrawal 
                       Console.Write("Enter amount to withdraw: ");
                       userMoney = Console.ReadLine();
                       Console.Write("Enter remark, necessary for transaction success: ");
                       var remark = Console.ReadLine();
                       if (!String.IsNullOrWhiteSpace(remark))
                       {
                          personCurrentAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                        
                       }
                       else { Console.WriteLine("Transaction fail, try again"); }
                    }

                    else if (customerResponse.ToLower() == "t")
                    {

                            //Perform Money transfer
                            var moneyTransfer = 0M;

                            string transferReceiverNumber = "";
                           // decimal transferReceiverBalance = 0;
                            var confirmTransfer = false;
                            //moneyTransfer = 0;
                            Console.Write("Enter account number for transfer: ");
                            transferReceiverNumber = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter amount to transfer: ");
                            userMoney = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter remark, necessary for transaction success: ");
                            var remark = Console.ReadLine();
                            Console.WriteLine();
                            if (!String.IsNullOrWhiteSpace(remark))
                            {

                              moneyTransfer =  personCurrentAccount.Transfer(Convert.ToDecimal(userMoney), remark, DateTime.Now);

                                foreach(var allAccount in bankAccountList)
                                {

                                    foreach (var segunAccount in currentAccountList)
                                    {

                                        if (segunAccount.AccountNumber == allAccount && segunAccount.AccountNumber == transferReceiverNumber)
                                        {

                                            // Transfer money to another customer account                      
                                            segunAccount.Deposit(Convert.ToDecimal(moneyTransfer), $"Money transfer from {segunAccount.AccountNumber}", DateTime.Now);
                                            Console.WriteLine("After recieve transfer " + segunAccount.Balance);
                                            transferReceiverBalance = segunAccount.Balance;
                                            confirmTransfer = true;
                                            break;
                                        }
                                        else
                                        {
                                            // Roll back money if transfer is not successful
                                            Console.WriteLine("Money rollback due to fail transfer, please try again");
                                            segunAccount.Deposit(Convert.ToDecimal(moneyTransfer), "Money rollback", DateTime.Now);
                                        }


                                    }

                                    if (confirmTransfer) { break; }
                                }
                                

                                //To confirm that the reciever of the transfer get the money
                                if (confirmTransfer)
                                {
                                    Console.WriteLine($"Customer with account number {transferReceiverNumber} received sum of #{moneyTransfer}:00");
                                    Console.WriteLine($"Current balance is: #{transferReceiverBalance}:00");
                                    confirmTransfer = false;
                                }
                                

                            }
                            else { Console.WriteLine("Transaction fail, try again"); }
                    }

                    else if (customerResponse.ToLower() != "q")
                    {
                       Console.WriteLine("Wrong input, try again");
                    }

                  } while (customerResponse != "q");

                    //Add all current account into list
                    currentAccountList.Add(personCurrentAccount);

                    //Get all account number from current account
                    foreach(var item in currentAccountList)
                    {
                        bankAccountList.Add(item.AccountNumber);
                    }

                    //Output Account balance for a particular account
                    Console.WriteLine("Generate Account Balance after transaction");
                    Console.WriteLine();
                  var accountBalanceBuilder = new StringBuilder();
                  //Console.WriteLine($"Account Balance after transaction");
                  accountBalanceBuilder.AppendLine("Account Number\t\tBalance");
                  accountBalanceBuilder.AppendLine($"{personCurrentAccount.AccountNumber}\t\t{personCurrentAccount.Balance}");
                  Console.WriteLine(accountBalanceBuilder.ToString());
                  Console.WriteLine();
                  
                    //Generate Statement of account
                    Console.WriteLine("Generated Statement of account");
                    Console.WriteLine();
                    Console.WriteLine(personCurrentAccount.AccountStatememt());

                }
               catch (InvalidOperationException e)
               {
                    Console.WriteLine("Error! " + e.Message);
               }
               catch(ArgumentOutOfRangeException)
               {
                    Console.WriteLine("Error! You cannot deposit zero or negative amount");
               }

            }

        }

        //Create savings account
        public void CreateSavingsAccount()
        {

                            //Create savings account
                            var moneyTransfer = 0M;
                            var savingsAccountList = new List<SavingsAccount>();
                            Console.Write("Enter the initial opening balance minimum of #100:00 : ");
                            userMoney = Console.ReadLine();
                            Console.WriteLine();

                            if (String.IsNullOrWhiteSpace(userMoney))
                            {
                                Console.WriteLine("Opening balance cannot be empty");
                            }
                            else
                            {
                                try
                                {
                                    var personSavingsAccount = new SavingsAccount(ownerName, Convert.ToDecimal(userMoney), accountType);
                                    Console.WriteLine(personSavingsAccount.AccountStatememt());

                                    do
                                    {
                                        Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money, \"T\" to transfer money or \"Q\" to terminate this transaction: ");
                                        customerResponse = Console.ReadLine();
                                        if(customerResponse.ToLower() == "d")
                                        {

                                            //Perform money deposit
                                            Console.Write("Enter amount to deposit: ");
                                            userMoney = Console.ReadLine();
                                            Console.Write("Enter remark, necessary for transaction success: ");
                                            var remark = Console.ReadLine();
            
                                            if (!String.IsNullOrWhiteSpace(remark))
                                            {
                                                personSavingsAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                      
                                            }
                                            else { Console.WriteLine("Transaction fail, try again"); }
                                        }
                                        else if(customerResponse.ToLower() == "w")
                                        {

                                            //Perform money withdrawal
                                            Console.Write("Enter amount to withdraw: ");
                                            userMoney = Console.ReadLine();
                                            Console.Write("Enter remark, necessary for transaction success: ");
                                            var remark = Console.ReadLine();
            
                                            if (!String.IsNullOrWhiteSpace(remark))
                                            {
                                                personSavingsAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                         
                                            }
                                            else { Console.WriteLine("Transaction fail, try again"); }
                                        }

                                        else if (customerResponse.ToLower() == "t")
                                        {

                                            //Perform Money transfer
                                            Console.Write("Enter account number for transfer: ");
                                            var userAccountNumber = Console.ReadLine();
                                            Console.Write("Enter amount to Transfer: ");
                                            userMoney = Console.ReadLine();
                                            Console.Write("Enter remark, necessary for transaction success: ");
                                            var remark = Console.ReadLine();

                                            if (!String.IsNullOrWhiteSpace(remark))
                                            {
                                                var confirmTransfer = false;
                                              moneyTransfer =  personSavingsAccount.Transfer(Convert.ToDecimal(userMoney), remark, DateTime.Now);


                                                foreach (var allAccount in bankAccountList)
                                                {

                                                    foreach (var segunAccount in savingsAccountList)
                                                    {

                                                        if (segunAccount.AccountNumber == allAccount && segunAccount.AccountNumber == userAccountNumber)
                                                        {

                                                            // Transfer money to another customer account                      
                                                            segunAccount.Deposit(Convert.ToDecimal(moneyTransfer), $"Money transfer from {segunAccount.AccountNumber}", DateTime.Now);
                                                            Console.WriteLine("After recieve transfer " + segunAccount.Balance);
                                                            transferReceiverBalance = segunAccount.Balance;
                                                            confirmTransfer = true;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            // Roll back money if transfer is not successful
                                                            Console.WriteLine("Money rollback due to fail transfer, please try again");
                                                            segunAccount.Deposit(Convert.ToDecimal(moneyTransfer), "Money rollback", DateTime.Now);
                                                        }


                                                    }

                                                    if (confirmTransfer) { break; }
                                                }


                            }
                                            else { Console.WriteLine("Transaction fail, try again"); }
                                        }

                                        else if(customerResponse.ToLower() != "q")
                                            {
                                                Console.WriteLine("Wrong input, try again");
                                            }

                                    } while (customerResponse.ToLower() != "q");

                                    //Add savings account to account list
                                    savingsAccountList.Add(personSavingsAccount);

                                    //Get all account number from savings account
                                    foreach (var item in savingsAccountList)
                                    {
                                        bankAccountList.Add(item.AccountNumber);
                                    }

                                    //Output Account balance for a particular account
                                    Console.WriteLine();
                                    var accountBalanceBuilder = new StringBuilder();
                                    Console.WriteLine($"Account Balance after transaction");
                                    Console.WriteLine();
                                    accountBalanceBuilder.AppendLine("\t\t\t\tAccount Number\t\t\t\t\t\tBalance");
                                    accountBalanceBuilder.AppendLine($"\t\t{personSavingsAccount.AccountNumber}\t\t\t\t\t\t{personSavingsAccount.Balance}");
                                    Console.WriteLine(accountBalanceBuilder.ToString());
                                    Console.WriteLine();
                                    //Generate statement of account
                                    Console.WriteLine("Generate statement of account");
                                    Console.WriteLine();
                                    Console.WriteLine(personSavingsAccount.AccountStatememt());
                                    Console.WriteLine();
                                }
                               catch (InvalidOperationException e)
                                {
                                    Console.WriteLine("Error! " + e.Message);
                                }
                            }

        }

    }
}
