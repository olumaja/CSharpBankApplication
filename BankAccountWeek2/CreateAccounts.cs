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

        public CreateAccounts()
        {
            Console.Write("Enter account type (choose Current or Savings Account) ");
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
                  var personCurrentAccount = new CurrentAccount("Segun Maja", Convert.ToDecimal(userMoney), accountType);
                  Console.WriteLine(personCurrentAccount.AccountStatememt());

                  do
                  {
                    Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money or \"Q\" to terminate this transaction: ");
                    customerResponse = Console.ReadLine();
                    if (customerResponse.ToLower() == "d")
                    {
                       Console.Write("Enter amount to deposit: ");
                       userMoney = Console.ReadLine();
                       Console.Write("Enter remark, necessary for transaction success: ");
                       var remark = Console.ReadLine();
                       Console.WriteLine();
                       if (!String.IsNullOrWhiteSpace(remark))
                       {
                          personCurrentAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                        //  Console.WriteLine(personCurrentAccount.AccountStatememt());
                       }
                       else { Console.WriteLine("Transaction fail, try again"); }
                    }
                    else if (customerResponse == "w")
                    {
                       Console.Write("Enter amount to withdraw: ");
                       userMoney = Console.ReadLine();
                       Console.Write("Enter remark, necessary for transaction success: ");
                       var remark = Console.ReadLine();
                       if (!String.IsNullOrWhiteSpace(remark))
                       {
                          personCurrentAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                        //  Console.WriteLine(personCurrentAccount.AccountStatememt());
                       }
                       else { Console.WriteLine("Transaction fail, try again"); }
                    }
                    else if (customerResponse.ToLower() != "q")
                    {
                       Console.WriteLine("Wrong input, try again");
                    }

                  } while (customerResponse != "q");

                    //Output Account balance for a particular account
                    Console.WriteLine("Generate Account Balance after transaction");
                    Console.WriteLine();
                  var accountBalanceBuilder = new StringBuilder();
                  Console.WriteLine($"Account Balance after transaction");
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
                                    var personSavingsAccount = new SavingsAccount("Segun Maja", Convert.ToDecimal(userMoney), accountType);
                                    Console.WriteLine(personSavingsAccount.AccountStatememt());

                                    do
                                    {
                                        Console.Write("Enter \"D\" to deposit money, \"W\" to withdraw money or \"Q\" to terminate this transaction: ");
                                        customerResponse = Console.ReadLine();
                                        if(customerResponse.ToLower() == "d")
                                        {
                                            Console.Write("Enter amount to deposit: ");
                                            userMoney = Console.ReadLine();
                                            Console.Write("Enter remark, necessary for transaction success: ");
                                            var remark = Console.ReadLine();
            
                                            if (!String.IsNullOrWhiteSpace(remark))
                                            {
                                                personSavingsAccount.Deposit(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                      //          Console.WriteLine(personSavingsAccount.AccountStatememt());
                                            }
                                            else { Console.WriteLine("Transaction fail, try again"); }
                                        }
                                        else if(customerResponse == "w")
                                        {
                                            Console.Write("Enter amount to withdraw: ");
                                            userMoney = Console.ReadLine();
                                            Console.Write("Enter remark, necessary for transaction success: ");
                                            var remark = Console.ReadLine();
            
                                            if (!String.IsNullOrWhiteSpace(remark))
                                            {
                                                personSavingsAccount.Withdrawal(Convert.ToDecimal(userMoney), remark, DateTime.Now);
                                         //       Console.WriteLine(personSavingsAccount.AccountStatememt());
                                            }
                                            else { Console.WriteLine("Transaction fail, try again"); }
                                        }
                                        else if(customerResponse.ToLower() != "q")
                                        {
                                            Console.WriteLine("Wrong input, try again");
                                        }

                                    } while (customerResponse.ToLower() != "q");

                                    //Output Account balance for a particular account
                                    Console.WriteLine("");
                                    var accountBalanceBuilder = new StringBuilder();
                                    Console.WriteLine($"Account Balance after transaction");
                                    Console.WriteLine();
                                    accountBalanceBuilder.AppendLine("\t\tAccount Number\t\t\t\tBalance");
                                    accountBalanceBuilder.AppendLine($"\t\t{personSavingsAccount.AccountNumber}\t\t\t\t{personSavingsAccount.Balance}");
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
